namespace MetroPass.Presentation.WebApi.Models.Response
{
    public class SwipeEntryResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;

        public string CardType { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public bool IsMonthlyPassValid { get; set; }
    }
}
