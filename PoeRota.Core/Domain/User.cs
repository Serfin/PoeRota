using System;

namespace PoeRota.Core.Domain
{
    public class User
    {
        // TODO : User validation
        public User(Guid userId, string email, string username, string password, string salt, string ign)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Password = password;
            Salt = salt;
            Ign = ign;
            CreatedAt = DateTime.UtcNow;
        }
        
        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Ign { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}