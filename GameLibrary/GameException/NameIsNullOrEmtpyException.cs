using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameException
{
    public class NameIsNullOrEmtpyException : Exception
    {
        public string Code => ExceptionCode.NameIsNullOrEmpty;
    }
}
