using KanbanBoard.Services.IdentityServer.Data.Entities.Abstract;

namespace KanbanBoard.Services.IdentityServer.Entities
{
    public sealed class User : BaseEntity
    {
        
        public string URL { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}
