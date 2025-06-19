using MetroPass.Domain.Enums;

namespace MetroPass.Domain.Entities;

public class Card
{
    public int CardId { get; set; }

    public int Balance { get; set; }

    public CardStatus CardStatus { get; set; }

    public bool IsActive
    {
        get
        {
            return CardStatus == CardStatus.Active;
        }
    }

    public bool IsMonthlyPass { get; set; }

    public DateTime MonthlyPassExpiredDate { get; set; }

    public bool IsMonthlyPassValid
    {
        get
        {
            return IsMonthlyPass && MonthlyPassExpiredDate >= DateTime.Today;
        }
    }

    public void Deduct(int fare)
    {
        if (Balance <= fare)
            throw new InvalidOperationException("餘額不足");

        Balance -= fare;
    }
}
