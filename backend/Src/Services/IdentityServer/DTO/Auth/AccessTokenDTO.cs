using KanbanBoard.Services.IdentityServer.Entities;

namespace KanbanBoard.Services.IdentityServer.DTO.Auth
{
    public sealed class AccessTokenDTO
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public AccessTokenDTO(AccessToken accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
