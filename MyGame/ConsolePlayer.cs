using System;
using System.Collections.Generic;
using System.Text;
using GameLibrary;

namespace MyGame
{
    public class Player : IPlayer
    {
        public string Name { get; }
        private Game _game;
        public Player(string name, Game game)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Недопустимы пустые имена.");

            Name = name;
            this._game = game;
        }
        private void Ending(string lineread)
        {
            if (lineread == "/exit")
            {
                Environment.Exit(0);
            }
        }
        public void Step()
        {
            _game.Last = Name;
            string lineread = Console.ReadLine();
            Ending(lineread);
            _game.NextStep(int.Parse(lineread));
        }
    }
}
