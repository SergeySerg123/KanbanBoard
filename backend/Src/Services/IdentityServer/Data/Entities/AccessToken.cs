using KanbanBoard.Services.IdentityServer.Data.Entities.Abstract;

namespace KanbanBoard.Services.IdentityServer.Entities
{
    public sealed class AccessToken : BaseEntity
    {
        public string Token { get; }
        public int ExpiresIn { get; }

        public AccessToken(string token, int expiresIn)
        {
            Token = token;
            ExpiresIn = expiresIn;
        }
    }
}
