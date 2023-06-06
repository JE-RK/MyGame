using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public abstract class Player : IPlayer
    {
        public string Name { get; }
        protected IGame _game;
        public Player(string name, IGame game)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Недопустимы пустые имена.");

            Name = name;
            _game = game;
        }

        public abstract void Step();

    }
}
