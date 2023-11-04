using System;

namespace E03.Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string EXC_MESSAGE = "Invalid number!";
        public InvalidNumberException()
            : base(EXC_MESSAGE)
        {

        }
        public InvalidNumberException(string message) 
            : base(message)
        {

        }
    }
}
