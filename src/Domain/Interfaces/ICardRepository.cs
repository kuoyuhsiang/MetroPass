using MetroPass.Domain.Entities;

namespace MetroPass.Domain.Interfaces;

public interface ICardRepository
{
    Task<Card> GetCardByCardNoAsync(string cardNo);

    Task SaveAsync(Card card);
}
