using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TOB
{
    class InvalidAccountTypeException : ApplicationException
    {
        
        public InvalidAccountTypeException()
        {
        }

        public InvalidAccountTypeException(string message) : base(message)
        {
        }

        public InvalidAccountTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAccountTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
