using MetroPass.Domain.Entities;
using MetroPass.Domain.Enums;
using MetroPass.Domain.Interfaces;

namespace MetroPass.Infrastructure.Repository;

public class InMemoryCardRepository : ICardRepository
{
    private static readonly List<Card> _card = new List<Card>
    {
        new() {
            Id = "MP0001",
            Name = "Shawn",
            Balance = 100,
            CardStatus = CardStatus.Active,
            IsMonthlyPass = false
        },
        new() {
            Id = "MP0002",
            Name = "Jason",
            Balance = 50,
            CardStatus = CardStatus.Active,
            IsMonthlyPass = true,
            MonthlyPassExpiredDate = DateTime.Today.AddDays(5)
        },
        new() {
            Id = "MP0003",
            Name = "Alex",
            Balance = 0,
            CardStatus = CardStatus.Inactive,
            IsMonthlyPass = false
        }
    };

    public Task<Card?> GetCardByCardNoAsync(string CardId)
    {
        var card = _card.FirstOrDefault(x => x.Id == CardId);
        return Task.FromResult(card);
    }

    public Task SaveAsync(Card card)
    {
        var index = _card.FindIndex(x => x.Id == card.Id);
        if (index >= 0)
        {
            _card[index] = card;
        }
        return Task.CompletedTask;
    }

}
