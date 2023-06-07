using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public class InvalidPlayerStepException : GameException
    {
        public InvalidPlayerStepException()
        {
            Code = ExceptionCode.InvalidPlayerStep;
        }
    }
}
