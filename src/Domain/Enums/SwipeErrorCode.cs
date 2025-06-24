namespace MetroPass.Domain.Enums
{
    public enum SwipeErrorCode
    {
        None = 0,
        CardNotFound = 1,
        CardNotActive = 2,
        InsufficientBalance = 3,
        MonthlyPassExpired = 4,
        UnknownError = 99
    }
}