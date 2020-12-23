using System;
using System.Text.Json.Serialization;

namespace IdentityServer.DTO.Auth
{
    public sealed class RefreshTokenDTO
    {
        public RefreshTokenDTO()
        {
            SigningKey = Environment.GetEnvironmentVariable("SecretJWTKey");
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        [JsonIgnore]
        public string SigningKey { get; private set; }
    }
}
