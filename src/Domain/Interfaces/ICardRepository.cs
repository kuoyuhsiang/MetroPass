using MetroPass.Domain.Entities;

namespace MetroPass.Domain.Interfaces;

public interface ICardRepository
{
    Task<Card?> GetCardByCardNoAsync(string cardId);

    Task SaveAsync(Card card);
}
