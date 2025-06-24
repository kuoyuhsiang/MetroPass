using MetroPass.Application.DTOs;
using MetroPass.Application.Interface;
using MetroPass.Domain.Enums;
using MetroPass.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace MetroPass.Application.Impl;

public class SwipeCardAppService : ISwipeCardAppService
{
    private readonly ICardRepository _cardRepository;
    private readonly ILogger<SwipeCardAppService> _logger;

    public SwipeCardAppService(ICardRepository cardRespository,
                               ILogger<SwipeCardAppService> logger)
    {
        _cardRepository = cardRespository;
        _logger = logger;
    }

    public async Task<SwipeResponseDTO> SwipeHandler(SwipeRequestDTO swipeRequestDTO)
    {
        var card = await _cardRepository.GetCardByCardNoAsync(swipeRequestDTO.CardId);

        if (card is null)
            throw new InvalidOperationException("查無此卡片");

        if (!card.IsActive)
            throw new InvalidOperationException("卡片未啟用");

        var response = new SwipeResponseDTO
        {
            CardType = card.CardType,
            IsMonthlyPassValid = card.IsMonthlyPassValid,
            IsSuccess = true
        };

        if (!card.IsSufficientBalance)
        {
            _logger.LogWarning("進站失敗：餘額不足");
            return new SwipeResponseDTO
            {
                IsSuccess = false,
                Message = "餘額不足",
                ErrorCode = SwipeErrorCode.InsufficientBalance
            };
        }

        if (card.IsMonthlyPassValid)
        {
            response.ExpiredDate = card.MonthlyPassExpiredDate;
            _logger.LogInformation($"進站成功（使用月票），月票有效至 {card.MonthlyPassExpiredDate:yyyy-MM-dd}");
            return response;
        }

        try
        {
            card.Deduct(card.Fare);
            await _cardRepository.SaveAsync(card);

            response.Balance = card.Balance;
            response.IsSuccess = true;
            response.CardType = card.CardType;
            _logger.LogInformation($"進站成功（儲值扣款），餘額為 {card.Balance}");
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "進站失敗：扣款過程發生錯誤");
            return new SwipeResponseDTO
            {
                IsSuccess = false,
                Message = "請詢問站務人員",
                ErrorCode = SwipeErrorCode.UnknownError
            };
        }
    }
}
