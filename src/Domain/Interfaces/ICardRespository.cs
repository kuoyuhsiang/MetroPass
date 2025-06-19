using MetroPass.Domain.Entities;

namespace MetroPass.Domain.Interfaces;

public interface ICardRespository
{
    Task<Card?> GetCardByCardIdAsync(int cardId);

    Task SaveAsync(Card card);
}
