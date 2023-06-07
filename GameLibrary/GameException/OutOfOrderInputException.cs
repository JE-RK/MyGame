using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public  class OutOfOrderInputException : GameException
    {
        public OutOfOrderInputException()
        {
            Code = ExceptionCode.OutOfOrderInput;
        }
    }
}
