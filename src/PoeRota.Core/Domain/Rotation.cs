using System;

namespace PoeRota.Core.Domain
{
    public class Rotation
    {
        // TODO : Rotation validation
        public Rotation(Guid rotationId, User creator, string league, string type)
        {
            RotationId = rotationId;
            Creator = creator;
            League = league;
            Type = type;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid RotationId { get; set; }
        public User Creator { get; protected set; }
        public string League { get; protected set; }
        public string Type { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}