using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        private int _step;
        Game game;
        public Player(string name, Game game)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new Exception("Недопустимы пустые имена.");
            }
            Name = name;
            this.game = game;
        }

        public void SetStep(int num)
        {
            _step = num;
        }
        public int Step()
        {
            game.Last = Name;
            return _step;
        }
    }
}
