using System;

namespace LatamQuants.PrimaryAPI.WebSocket.Serialization
{
    internal class InvalidEnumStringException : Exception
    {
        private const string InvalidEnumError = "Invalid enum/string value: ";

        public InvalidEnumStringException(string enumValue) : base(InvalidEnumError + enumValue) {}
    }
}