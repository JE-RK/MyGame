using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace MyGame2
{
    public class FormPlayer : IPlayer
    {
        public string Name { get; }
        private Game _game;
        public FormPlayer(string name, Game game)
        {
            if (String.IsNullOrEmpty(name))
                throw new Exception("Недопустимы пустые имена.");

            Name = name;
            _game = game;
        }
        public delegate int RegStep();
        public RegStep StepMethod { get; set; }
        public void Step()
        {
            _game.NextStep(StepMethod());
        }
    }
}
