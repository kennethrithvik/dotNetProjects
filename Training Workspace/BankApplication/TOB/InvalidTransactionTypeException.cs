using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TOB
{
    class InvalidTransactionTypeException : Exception
    {
        public InvalidTransactionTypeException()
        {
        }

        public InvalidTransactionTypeException(string message) : base(message)
        {
        }

        public InvalidTransactionTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTransactionTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
