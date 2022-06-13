using System;
using System.Runtime.Serialization;

namespace OnScreenSizeMarkup.Maui.Exceptions
{
    public class XamlMarkupException : Exception
    {
        public XamlMarkupException()
        {
        }

        public XamlMarkupException(string message) : base(message)
        {
        }

        public XamlMarkupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XamlMarkupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
