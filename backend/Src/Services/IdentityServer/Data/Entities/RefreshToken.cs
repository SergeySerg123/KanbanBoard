using KanbanBoard.Services.IdentityServer.Data.Entities.Abstract;
using KanbanBoard.Services.IdentityServer.Entities;
using System;

namespace KanbanBoard.Services.IdentityServer.Data.Entities
{
    public sealed class RefreshToken : BaseEntity
    {
        private const int DAYS_TO_EXPIRE = 5;

        public RefreshToken()
        {
            Expires = DateTime.UtcNow.AddDays(DAYS_TO_EXPIRE);
        }

        public string Token { get; set; }
        public DateTime Expires { get; private set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public bool IsActive => DateTime.UtcNow <= Expires;
    }
}
