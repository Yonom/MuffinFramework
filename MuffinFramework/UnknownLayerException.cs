using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
