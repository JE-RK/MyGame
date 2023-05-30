﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public class Player : IPlayer
    {
        public string Name { get; }
        private int _step;
        private Game _game;
        public Player(string name, Game game)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Недопустимы пустые имена.");

            Name = name;
            this._game = game;
        }

        public void SetStep(int num)
        {
            _step = num;
        }
        public int Step()
        {
            _game.Last = Name;
            return _step;
        }
    }
}
