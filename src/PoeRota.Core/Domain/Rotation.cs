using System;

namespace PoeRota.Core.Domain
{
    public class Rotation
    {
        public Rotation(Guid rotationId, Guid creator, string league, string type, int? spots)
        {
            RotationId = rotationId;
            SetCreator(creator);
            SetLeague(league);
            SetType(type);
            SetSpots(spots);
            CreatedAt = DateTime.UtcNow;
        }

        public Guid RotationId { get; protected set; }
        public Guid Creator { get; protected set; }
        public string League { get; protected set; }
        public string Type { get; protected set; }
        public int? Spots { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        private void SetCreator(Guid creator)
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

        private void SetSpots(int? spots)
        {
            if (spots == null)
            {
                throw new Exception("Number of spots cannot be empty");
            }
            if (spots < 1)
            {
                throw new Exception("Number of spots must be greater than 0");
            }
            if (spots > 5)
            {
                throw new Exception("Number of spots cannot be greater than 5");
            }

            Spots = spots;
        }
    }
}