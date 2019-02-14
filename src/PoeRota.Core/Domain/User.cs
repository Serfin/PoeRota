using System;

namespace PoeRota.Core.Domain
{
    public class User
    {
        // TODO : User validation
        public User(Guid userId, string email, string username, string hash,
            string salt, string ign, string role)
        {
            UserId = userId;
            Email = email;
            Username = username;
            Hash = hash;
            Salt = salt;
            Ign = ign;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Hash { get; protected set; }
        public string Salt { get; protected set; }
        public string Ign { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}