using System;
using System.Collections.Generic;
using System.Text;
using GameLibrary.GameException;

namespace GameLibrary
{
    public abstract class Player : IPlayer
    {
        public string Name { get; }
        protected IGame _game;
        public Player(string name, IGame game)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new NameIsNullOrEmtpyException();
            Name = name;
            _game = game;
        }

        public abstract void Step();
    }
}
