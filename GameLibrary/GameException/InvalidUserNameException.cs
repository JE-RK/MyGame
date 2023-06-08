using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public class InvalidUserNameException : GameException
    {
        public InvalidUserNameException()
        {
            Code = ExceptionCode.InvalidPlayersName;
        }
    }
}
