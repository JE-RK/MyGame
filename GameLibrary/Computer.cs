using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Computer : IPlayer
    {
        public string Name { get; } = "Bot";
        private List<int> _numbers = new List<int>() { 12, 23, 34, 45, 56, 67, 78, 89, 100 };
        private IGame _game;
        public Computer(IGame game)
        {
            _game = game;
        }
        private int Think()
        {
            if (_game.Score == 0)
            {
                return 1;
            }
            else if (_game.Score == 1 || _numbers.Contains(_game.Score))
            {
                Random random = new Random();
                return random.Next(1, 11);
            }
            else
            {
                int findnum = 0;
                foreach (var number in _numbers)
                {
                    if (_game.Score < number)
                    {
                        findnum = number;
                        break;
                    }
                }
                return findnum - _game.Score;
            }
        }
        public void Step() => _game.NextStep(Think(), this);
    }
}
