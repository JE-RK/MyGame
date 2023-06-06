using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public interface IGame
    {
        int Score { get; }
        void NextStep(int number, IPlayer player);
    }
}
