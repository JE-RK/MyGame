using System;
using System.Collections.Generic;
using System.Text;
using GameLibrary;

namespace MyGame
{
    public class ConsolePlayer : Player
    {
        public ConsolePlayer(string name, IGame game) : base(name, game) { }

        private void Ending(string lineread)
        {
            if (lineread == "/exit")
            {
                Environment.Exit(0);
            }
        }
        public override void Step()
        {
            string lineread = Console.ReadLine();
            Ending(lineread);
            _game.NextStep(int.Parse(lineread), this);
        }
    }
}
