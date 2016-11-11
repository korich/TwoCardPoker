using Implementation;
using Xunit;

namespace UnitTest
{
    public class HandTests
    {
        [Fact]
        public void ReturnsCorrectCards()
        {
            var handOne = new Hand(new Card(SuitEnum.Clubs, 13), new Card(SuitEnum.Hearts, 14));
            var handTwo = new Hand(new Card(SuitEnum.Spades, 11), new Card(SuitEnum.Diamonds, 12));
            var handThree = new Hand(new Card(SuitEnum.Clubs, 2), new Card(SuitEnum.Hearts, 3));
            var handFour = new Hand(new Card(SuitEnum.Spades, 5), new Card(SuitEnum.Diamonds, 9));

            Assert.Equal("King of Clubs, Ace of Hearts", handOne.ToString());
            Assert.Equal("Jack of Spades, Queen of Diamonds", handTwo.ToString());
            Assert.Equal("2 of Clubs, 3 of Hearts", handThree.ToString());
            Assert.Equal("5 of Spades, 9 of Diamonds", handFour.ToString());
        }

        [Fact]
        public void SuitOrder()
        {
            var dimondHand = new Hand(new Card(SuitEnum.Diamonds, 13), new Card(SuitEnum.Hearts, 3));
            var heartHand = new Hand(new Card(SuitEnum.Hearts, 13), new Card(SuitEnum.Diamonds, 3));
            var clubHand = new Hand(new Card(SuitEnum.Clubs, 13), new Card(SuitEnum.Spades, 3));
            var spadeHand = new Hand(new Card(SuitEnum.Spades, 13), new Card(SuitEnum.Clubs, 3));

            Assert.True(dimondHand.Score() < heartHand.Score());
            Assert.True(heartHand.Score() < clubHand.Score());
            Assert.True(clubHand.Score() < spadeHand.Score());
        }

        [Fact]
        public void HandRanks()
        {
            var straightFlushHand = new Hand(new Card(SuitEnum.Diamonds, 2), new Card(SuitEnum.Diamonds, 3));
            var flushHand = new Hand(new Card(SuitEnum.Diamonds, 2), new Card(SuitEnum.Diamonds, 9));
            var straightHand = new Hand(new Card(SuitEnum.Clubs, 2), new Card(SuitEnum.Spades, 3));
            var pairHand = new Hand(new Card(SuitEnum.Spades, 2), new Card(SuitEnum.Clubs, 2));
            var highHand = new Hand(new Card(SuitEnum.Spades, 14), new Card(SuitEnum.Clubs, 3));
            var lowHand = new Hand(new Card(SuitEnum.Spades, 6), new Card(SuitEnum.Clubs, 3));

            Assert.True(straightFlushHand.Score() > flushHand.Score(), "Stright Flush > Stright");
            Assert.True(flushHand.Score() > straightHand.Score(), "Flush > Stright");
            Assert.True(straightHand.Score() > pairHand.Score(), "Stright > Pair");
            Assert.True(pairHand.Score() > highHand.Score(), "Pair > High");
            Assert.True(highHand.Score() > lowHand.Score(), "High > Low");
        }


        [Fact]
        public void HandNames()
        {
            var straightFlushHand = new Hand(new Card(SuitEnum.Diamonds, 2), new Card(SuitEnum.Diamonds, 3));
            var flushHand = new Hand(new Card(SuitEnum.Diamonds, 2), new Card(SuitEnum.Diamonds, 9));
            var straightHand = new Hand(new Card(SuitEnum.Clubs, 2), new Card(SuitEnum.Spades, 3));
            var pairHand = new Hand(new Card(SuitEnum.Spades, 2), new Card(SuitEnum.Clubs, 2));
            var highHand = new Hand(new Card(SuitEnum.Spades, 14), new Card(SuitEnum.Clubs, 3));
            var aceStright = new Hand(new Card(SuitEnum.Spades, 2), new Card(SuitEnum.Clubs, 14));
            var reverseStright = new Hand(new Card(SuitEnum.Spades, 5), new Card(SuitEnum.Clubs, 4));

            Assert.Equal(straightFlushHand.HandName(), "Stright Flush");
            Assert.Equal(flushHand.HandName(), "Flush");
            Assert.Equal(straightHand.HandName(), "Stright");
            Assert.Equal(pairHand.HandName(), "Pair");
            Assert.Equal(highHand.HandName(), "High Card");
            Assert.Equal(aceStright.HandName(), "Stright");
            Assert.Equal(reverseStright.HandName(), "Stright");
        }
    }
}
