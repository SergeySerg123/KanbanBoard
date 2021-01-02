using System;

namespace KanbanBoard.Api.Exceptions
{
    public sealed class InvalidConfirmPasswordTokenException : Exception
    {
        public InvalidConfirmPasswordTokenException() : base("Invalid confirm password token exception.") { }
    }
}
