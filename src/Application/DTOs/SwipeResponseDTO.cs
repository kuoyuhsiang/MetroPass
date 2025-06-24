using MetroPass.Domain.Enums;

namespace MetroPass.Application.DTOs
{
    public class SwipeResponseDTO
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public CardType CardType { get; set; }

        public decimal Balance { get; set; }

        public DateTime ExpiredDate { get; set; }

        public bool IsMonthlyPassValid { get; set; }

        public SwipeErrorCode ErrorCode { get; set; } = SwipeErrorCode.None;
    }
}