using MetroPass.Application.DTOs;
using MetroPass.Domain.Interfaces;

namespace MetroPass.Application.Impl;

public class SwipeCardAppService
{
    private readonly ICardRepository _cardRepository;

    public SwipeCardAppService(ICardRepository cardRespository)
    {
        _cardRepository = cardRespository;
    }

    public async Task<string> SwipeHandler(SwipeRequestDTO swipeRequestDTO)
    {
        var card = await _cardRepository.GetCardByCardNoAsync(swipeRequestDTO.CardNo);

        if (card is null)
            return "查無此卡片";

        if (!card.IsActive)
            return "卡片未啟用";

        if (card.IsMonthlyPassValid)
        {
            return $"進站成功（使用月票），月票有效至 {card.MonthlyPassExpiredDate.ToString("yyyy-MM-dd")}";
        }

        try
        {
            card.Deduct(swipeRequestDTO.Fare);
            await _cardRepository.SaveAsync(card);
            return $"進站成功，餘額：{card.Balance}";
        }
        catch (Exception ex)
        {
            return $"失敗 : {ex.Message}";
        }
    }
}
