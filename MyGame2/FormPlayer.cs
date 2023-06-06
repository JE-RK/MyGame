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
        public FormPlayer(string name, IGame game) : base(name, game) { }

        public delegate int RegStep();
        public RegStep StepMethod { get; set; }
        public override void Step() => _game.NextStep(StepMethod(), this);
    }
}
