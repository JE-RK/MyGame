using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public  class OutOfOrderInputException : Exception
    {
        public string Code => ExceptionCode.OutOfOrderInput;
    }
}
