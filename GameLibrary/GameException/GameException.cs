using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public abstract class GameException : Exception
    {
        public string Code;
    }
}
