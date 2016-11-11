using System;
using System.Collections.Generic;
using System.Linq;

namespace Implementation
{
    public class Game
    {
        private readonly Dictionary<int, int> _players;
        private readonly int _rounds;
        private int _currentRound = 1;
        private readonly Deck _deck;

        public Game(int playerCount, int rounds)
        {
            _deck = new Deck();
            _players = new Dictionary<int, int>();
            for (int i = 0; i < playerCount; i++)
            {
                _players.Add(i+1, 0);
            }
            _rounds = rounds;
        }

        public bool GameOver => (_rounds < _currentRound);

        public IOrderedEnumerable<KeyValuePair<int, int>> GetScores() => _players.OrderByDescending(x => x.Value);

        public void ShowScores()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("=============");
            Console.WriteLine("== Points  ==");
            Console.WriteLine("=============");
            Console.WriteLine("");
            foreach (var player in GetScores())
            {
                Console.WriteLine($"Player: {player.Key}, Score: {player.Value}");
            }
        }

        public void PlayRound()
        {
            _deck.Shuffle();

            var hands = new Dictionary<int, Hand>();

            for (int i = 1; i < _players.Count + 1; i++)
            {
                hands.Add(i, new Hand(_deck.Deal(), _deck.Deal()));
            }


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("=======================");
            Console.WriteLine($"== Round {_currentRound} Results ==");
            Console.WriteLine("=======================");
            Console.WriteLine("");

            int points = 0;

            foreach (var result in hands.OrderBy(x => x.Value.Score()))
            {
                Console.WriteLine($"Player: {result.Key}, Hand: {result.Value}({result.Value.HandName()}), Points = {points}");

                _players[result.Key] = _players[result.Key] + points;

                points++;
            }

            _currentRound++;
        }
        
    }
}
