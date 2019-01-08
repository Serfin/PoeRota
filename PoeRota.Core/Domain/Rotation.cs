using System;

namespace PoeRota.Core.Domain
{
    public class Rotation
    {
        // TODO : Rotation validation
        public Rotation(User creator, string league, string type)
        {
            Creator = creator;
            League = league;
            Type = type;
            CreatedAt = DateTime.UtcNow;
        }

        public User Creator { get; protected set; }
        public string League { get; protected set; }
        public string Type { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}