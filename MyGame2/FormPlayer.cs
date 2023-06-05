using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary;

namespace MyGame2
{
    public class FormPlayer : Player
    {
        public string Name { get; }
        private Game _game;
        public FormPlayer(string name, Game game) : base(name, game) { }

        public delegate int RegStep();
        public RegStep StepMethod { get; set; }
        public override void Step() => _game.NextStep(StepMethod(), this);
    }
}
