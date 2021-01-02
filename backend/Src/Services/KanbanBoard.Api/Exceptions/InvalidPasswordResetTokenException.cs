using System;

namespace KanbanBoard.Api.Exceptions
{
    public class InvalidPasswordResetTokenException : Exception
    {
        public InvalidPasswordResetTokenException() : base("Invalid password reset token.") { }
    }
}
