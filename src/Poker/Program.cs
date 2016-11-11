using System;
using Implementation;

namespace Poker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int playerCount = 0;

            while (playerCount == 0)
            {
                Console.Write("Enter Number of Players(2-6):");
                var playerCountKey = Console.ReadKey().KeyChar.ToString();
                if (int.TryParse(playerCountKey, out playerCount) &&
                    ((playerCount < 2) || (playerCount > 6)))
                {
                    playerCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a number between 2 and 6.");
                }
            }

            int roundCount = 0;

            Console.WriteLine("");
            while (roundCount == 0)
            {
                Console.Write("Enter Number of Rounds(2-5):");
                var roundCountKey = Console.ReadKey().KeyChar.ToString();
                if (int.TryParse(roundCountKey, out roundCount) &&
                    ((roundCount < 2) || (roundCount > 5)))
                {
                    roundCount = 0;
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a number between 2 and 5.");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("");



            var game = new Game(playerCount, roundCount);

            while (!game.GameOver)
            {
                game.PlayRound();
            }

            game.ShowScores();


            Console.ReadKey();
        }
    }
}
