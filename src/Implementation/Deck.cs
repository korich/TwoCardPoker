using System;
using System.Collections.Generic;

namespace Implementation
{
    public class Deck
    {
        public readonly List<Card> Cards;
        private int _topCard = 0;
        private Random _r = new Random();

        public Deck()
        {
            Cards = new List<Card>();

            for (int i = 1; i < 5; i++)
            {
                for (int j = 2; j < 15; j++)
                {
                    Cards.Add(new Card((SuitEnum)i, j));
                }
            }
        }

        public void Shuffle()
        {
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = _r.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }

            _topCard = 0;
        }

        public Card Deal()
        {
            if (_topCard == 52) //Reshuffle if deck is used up
            {
                Shuffle();
            }

            var card = Cards[_topCard];

            _topCard++;

            return card;
        }

        public Hand DealHand()
        {
            return new Hand(Deal(), Deal());
        }
    }
}
