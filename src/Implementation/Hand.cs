using System;
using System.Linq;

namespace Implementation
{

    public class Hand
    {
        private readonly Card _one;
        private readonly Card _two;

        public Hand(Card one, Card two)
        {
            if (one == null || two == null)
            {
                throw new NullReferenceException();
            }

            _one = one;
            _two = two;
        }

        private bool Flush()
        {
            return _one.Suit == _two.Suit;
        }

        private bool Stright()
        {
            //For a stright a Ace behaves as 1 not a 14
            var numberOne = _one.Number;
            if (numberOne == 14)
            {
                numberOne = 1;
            }
            var numberTwo = _two.Number;
            if (numberTwo == 14)
            {
                numberTwo = 1;
            }

            return Math.Abs(numberOne - numberTwo) == 1;
        }

        private bool Pair()
        {
            return _one.Number == _two.Number;
        }

        private decimal ScoreCard(Card card)
        {
            return card.Number + SuitModifier(card);
        }

        private decimal ScoreCards()
        {
            var cardsPoints = new[]
                {
                    ScoreCard(_one),
                    ScoreCard(_two)
                };

            //there will always be a card so no need to check for null
             return cardsPoints.OrderBy(x => x).Last();
        }

        private decimal SuitModifier(Card card)
        {
            return (decimal) card.Suit / 10;
        }

        public string HandName()
        {
            if (Flush() && Stright())
            {
                return "Stright Flush";
            }
            if (Flush())
            {
                return "Flush";
            }
            if (Stright())
            {
                return "Stright";
            }
            if (Pair())
            {
                return "Pair";
            }

            return "High Card";
        }

        public decimal Score()
        {
            decimal score = ScoreCards();

            if (Flush() && Stright())
            {
                score = score * 10000;
            } else if (Flush())
            {
                score = score * 1000;
            } else if (Stright())
            {
                score = score * 100;
            }
            else if (Pair())
            {
                score = score * 10;
            }


            return score;
        }

        public override string ToString()
        {
            return $"{_one}, {_two}";
        }
    }
}
