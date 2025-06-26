using MetroPass.Domain.Enums;

namespace MetroPass.Domain.Entities;

public class Card
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public int Balance { get; set; }

    public CardStatus CardStatus { get; set; }

    public CardType CardType { get; set; }

    public int Fare { get; set; }

    public bool IsActive
    {
        get
        {
            return CardStatus == CardStatus.Active;
        }
    }

    public bool IsMonthlyPass { get; set; }

    public DateTime MonthlyPassExpiredDate { get; set; }
    
    public bool IsSufficientBalance
    {
        get
        {
            return Balance > 0;
        }
    }

    public bool IsMonthlyPassValid
    {
        get
        {
            return IsMonthlyPass && MonthlyPassExpiredDate >= DateTime.Today;
        }
    }

    public void Deduct(int fare)
    {
        Balance -= fare;
    }
}
