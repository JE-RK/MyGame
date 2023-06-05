using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Player : IPlayer
    {
        public string Name { get; }
        protected Game _game;
        public Player(string name, Game game)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Недопустимы пустые имена.");

            Name = name;
            _game = game;
        }

        public virtual void Step() { }

    }
}
