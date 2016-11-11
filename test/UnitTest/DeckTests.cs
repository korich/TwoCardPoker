using Implementation;
using Xunit;

namespace UnitTest
{
    public class DeckTests
    {
        [Fact]
        public void HasFiftyTwoCards()
        {
            var deck = new Deck();

            Assert.Equal(deck.Cards.Count, 52);
        }

        [Fact]
        public void Deal()
        {
            var deck = new Deck();

            var card = deck.Deal();

            Assert.IsType<Card>(card);
            Assert.NotNull(card);

            var card2 = deck.Deal();
            Assert.IsType<Card>(card2);
            Assert.NotNull(card2);
            Assert.NotEqual(card, card2);
        }

        [Fact]
        //Check that the deck reshuffles when more than 52 cards drawn
        public void DealMoreThan52() 
        {
            var deck = new Deck();

            for (int i = 0; i < 70; i++)
            {
                deck.Deal();
            }
        }

        [Fact]
        public void DealHand()
        {
            var deck = new Deck();

            var hand = deck.DealHand();

            Assert.IsType<Hand>(hand);
            Assert.NotNull(hand);

            var hand2 = deck.DealHand();

            Assert.IsType<Hand>(hand2);
            Assert.NotNull(hand2);

            Assert.NotEqual(hand, hand2);
        }

        [Fact]
        public void CanShuffle()//This could file if shuffle randamonly returns the same 
        {
            var deck = new Deck();
            var deck2 = new Deck();
            
            Assert.True(CardsInSameOrder(deck, deck2), "Before Shuffle should be the same.");

            deck2.Shuffle();
            Assert.False(CardsInSameOrder(deck, deck2), "After Shuffle should be the different.");
        }

        private bool CardsInSameOrder(Deck deck1, Deck deck2)
        {
            for (int i = 0; i < 51; i++)
            {
                if (deck1.Cards[i].ToString() != deck2.Cards[i].ToString())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
