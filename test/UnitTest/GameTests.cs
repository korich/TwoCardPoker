using System.Linq;
using Implementation;
using Xunit;

namespace UnitTest
{
    public class GameTests
    {

        [Fact]
        public void PalyerCount()
        {
            var game = new Game(5, 5);

            Assert.Equal(game.GetScores().Count(), 5);
        }

        [Fact]
        public void RoundCount()
        {
            var game = new Game(5, 5);

            for (int i = 0; i < 5; i++)
            {
                Assert.False(game.GameOver);
                game.PlayRound();
            }

            Assert.True(game.GameOver);
        }
    }
}
