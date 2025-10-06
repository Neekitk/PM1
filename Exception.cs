using System;

namespace Exceptions
{
    class InvalidActionException : Exception
    {
        public InvalidActionException(string message) : base(message) { }
    }
}
