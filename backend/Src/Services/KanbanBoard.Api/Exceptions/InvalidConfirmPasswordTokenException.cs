using System;

namespace KanbanBoard.Services.Goals.Api.Exceptions
{
    public sealed class InvalidConfirmPasswordTokenException : Exception
    {
        public InvalidConfirmPasswordTokenException() : base("Invalid confirm password token exception.") { }
    }
}
