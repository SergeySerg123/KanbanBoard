using System;

namespace KanbanBoard.Services.Goals.Api.Exceptions
{
    public sealed class InvalidUsernameOrPasswordException : Exception
    {
        public InvalidUsernameOrPasswordException() : base("Invalid username or password.") { }
    }
}
