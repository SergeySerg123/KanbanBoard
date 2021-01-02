using IdentityServer.DTO.Auth;

namespace IdentityServer.DTO.User
{
    public sealed class AuthUserDTO
    {
        public UserDTO User { get; set; }
        public AccessTokenDTO Token { get; set; }
    }
}
