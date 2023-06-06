using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public class InavalidUserNameException : Exception
    {
        public string Code => ExceptionCode.InvalidPlayerName;
    }
}
