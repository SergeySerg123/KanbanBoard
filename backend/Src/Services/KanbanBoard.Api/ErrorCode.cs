namespace KanbanBoard.Services.Goals.Api
{
    public enum ErrorCode
    {
        General = 1,
        NotFound,
        InvalidUsernameOrPassword,
        InvalidToken,
        ExpiredRefreshToken
    }
}
