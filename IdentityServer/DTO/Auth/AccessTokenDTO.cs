using IdentityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.DTO.Auth
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
