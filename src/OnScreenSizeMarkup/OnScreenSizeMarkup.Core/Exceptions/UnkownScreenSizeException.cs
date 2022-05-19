using System;
using System.Runtime.Serialization;

namespace OnScreenSizeMarkup.Core.Exceptions
{
    public class UnkownScreenSizeException: Exception
    {
        public UnkownScreenSizeException()
        {
        }

        public UnkownScreenSizeException(string message) : base(message)
        {
        }

        public UnkownScreenSizeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnkownScreenSizeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
