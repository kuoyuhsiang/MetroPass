using MetroPass.DomainModel.Enum;

namespace MetroPass.DomainModel.Model
{

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
    }
}
