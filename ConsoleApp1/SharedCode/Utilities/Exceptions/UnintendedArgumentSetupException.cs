using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GameCollection.SharedCode.Utilities.Exceptions
{
    class UnintendedArgumentSetupException : ArgumentException
    {
        //uses inherited base class implementation
        public UnintendedArgumentSetupException()
        {
        }

        public UnintendedArgumentSetupException(string message) : base(message)
        {
        }

        public UnintendedArgumentSetupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UnintendedArgumentSetupException(string paramName, string message) : base(message, paramName)
        {
        }

        public UnintendedArgumentSetupException(string paramName, string message, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected UnintendedArgumentSetupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
