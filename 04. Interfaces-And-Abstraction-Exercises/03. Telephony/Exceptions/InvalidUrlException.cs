using System;

namespace E03.Telephony.Exceptions
{
    public class InvalidUrlException : Exception
    {
        private const string EXC_MESSAGE = "Invalid URL!";
        public InvalidUrlException()
            :base(EXC_MESSAGE)
        {
        }

        public InvalidUrlException(string message)
            : base(message)
        {
        }
    }
}
