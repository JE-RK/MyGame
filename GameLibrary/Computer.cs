using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Computer : IPlayer
    {
        public string Name { get; set; }
        private List<int> _numbers = new List<int>() { 12, 23, 34, 45, 56, 67, 78, 89, 100 };
        Game game;
        private int _step;
        //public int Move { get { return _step; } } 
        public Computer(Game game)
        {
            this.game = game;
            Name = "Bot";
        }
        public void Think()
        {
            game.Last = Name;
            if (game.Score == 0)
            {
                _step = 1;
            }
            else if (game.Score == 1 || _numbers.Contains(game.Score))
            {
                Random random = new Random();
                _step = random.Next(1, 11);
            }
            else
            {
                int findnum = 0;
                foreach (var number in _numbers)
                {
                    if (game.Score < number)
                    {
                        findnum = number;
                        break;
                    }
                }
                _step = findnum - game.Score;
            }
        }
        public void SetStep(int num)
        {
            _step = num;
        }
        public int Step()
        {
            Think();
            return _step;
        }
    }
}
