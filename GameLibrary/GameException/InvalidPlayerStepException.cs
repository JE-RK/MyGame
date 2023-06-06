using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public class InvalidPlayerStepException : Exception
    {
        public string Code => ExceptionCode.InvalidPlayerStep;
    }
}
