using System;

namespace KanbanBoard.Services.Goals.Api.Exceptions
{
    public class InvalidPasswordResetTokenException : Exception
    {
        public InvalidPasswordResetTokenException() : base("Invalid password reset token.") { }
    }
}
