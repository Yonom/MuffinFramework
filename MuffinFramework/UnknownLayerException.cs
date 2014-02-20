using System;

namespace MuffinFramework
{
    internal class UnknownLayerException : Exception
    {
        public UnknownLayerException()
        {
        }

        public UnknownLayerException(string message)
            : base(message)
        {
        }

        public UnknownLayerException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
