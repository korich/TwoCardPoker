namespace Implementation
{

    public class Card
    {
        public SuitEnum Suit { get; set; }
        public int Number { get; set; }

        public Card(SuitEnum suit, int number)
        {
            Suit = suit;
            Number = number;
        }

        public override string ToString()
        {
            string cardNumber;

            switch (Number)
            {
                case 11:
                    cardNumber = "Jack";
                    break;
                case 12:
                    cardNumber = "Queen";
                    break;
                case 13:
                    cardNumber = "King";
                    break;
                case 14:
                    cardNumber = "Ace";
                    break;
                default:
                    cardNumber = Number.ToString();
                    break;
            }

            return $"{cardNumber} of {Suit}";
        }
    }

}