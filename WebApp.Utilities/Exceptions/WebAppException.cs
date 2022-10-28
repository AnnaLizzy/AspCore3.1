using System;

namespace WebApp.Utilities.Exceptions
{
    public class WebAppException : Exception
    {
        public WebAppException()
        {

        }
        public WebAppException(string message) : base(message)
        {

        }
        public WebAppException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
