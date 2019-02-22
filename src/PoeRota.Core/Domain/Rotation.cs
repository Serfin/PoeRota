using System;

namespace PoeRota.Core.Domain
{
    public class Rotation
    {
        public Rotation(Guid rotationId, User creator, string league, string type)
        {
            RotationId = rotationId;
            SetCreator(creator);
            SetLeague(league);
            SetType(type);
            CreatedAt = DateTime.UtcNow;
        }

        public Guid RotationId { get; protected set; }
        public User Creator { get; protected set; }
        public string League { get; protected set; }
        public string Type { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        private void SetCreator(User creator)
        {
            if (creator == null)
            {
                throw new Exception("Rotation must contain creator");
            }

            Creator = creator;
        }

        private void SetType(string type)
        {
            if (String.IsNullOrWhiteSpace(type))
            {
                throw new Exception("Type cannot be empty");
            }

            Type = type;
        }

        private void SetLeague(string league)
        {
            if (String.IsNullOrWhiteSpace(league))
            {
                throw new Exception("League name cannot be empty");
            }

            League = league;
        }
    }
}