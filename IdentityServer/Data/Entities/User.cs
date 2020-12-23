using MongoDB.Bson;

namespace IdentityServer.Entities
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string URL { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}
