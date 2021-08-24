using System;

namespace GSXApi.Models
{
    public class GSXException : Exception
    {
        public GSXException()
        {
        }

        public GSXException(string message)
            : base(message)
        {
        }

        public GSXException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}