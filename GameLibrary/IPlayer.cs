using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary
{
    public interface IPlayer
    {
        string Name { get; }
        void Step();
    }
}
