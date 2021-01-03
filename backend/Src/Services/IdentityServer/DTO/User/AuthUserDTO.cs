using KanbanBoard.Services.IdentityServer.DTO.Auth;

namespace KanbanBoard.Services.IdentityServer.DTO.User
{
    public sealed class AuthUserDTO
    {
        public UserDTO User { get; set; }
        public AccessTokenDTO Token { get; set; }
    }
}
