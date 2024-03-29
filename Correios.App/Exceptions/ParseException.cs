﻿using System.Runtime.Serialization;

namespace Correios.App.Exceptions
{
    [Serializable]
    public class ParseException : Exception
    {
        public ParseException() { }
        public ParseException(string message) : base(message) { }
        public ParseException(string message, Exception inner) : base(message, inner) { }
        protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
