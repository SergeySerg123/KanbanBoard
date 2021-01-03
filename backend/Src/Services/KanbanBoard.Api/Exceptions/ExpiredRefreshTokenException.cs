using System;

namespace KanbanBoard.Services.Goals.Api.Exceptions
{
    public sealed class ExpiredRefreshTokenException : Exception
    {
        public ExpiredRefreshTokenException() : base("Refresh token expired.") { }
    }
}
