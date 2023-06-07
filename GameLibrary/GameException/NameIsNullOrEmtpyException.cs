using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public class NameIsNullOrEmtpyException : GameException
    {
        public NameIsNullOrEmtpyException()
        {
            Code = ExceptionCode.NameIsNullOrEmpty;
        }
    }
}
