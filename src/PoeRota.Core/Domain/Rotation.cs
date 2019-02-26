using System;
using System.Collections.Generic;

namespace PoeRota.Core.Domain
{
    public class Rotation
    {
        private ISet<User> _members = new HashSet<User>();
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
        public IEnumerable<User> Members 
        { 
            get { return _members; }
            protected set { _members = new HashSet<User>(); }
        }
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

        public void AddMember(User member)
        {
            if (member == null)
            {
                throw new Exception("Cannot add empty user");
            }
            if (Spots == 0 )
            {
                throw new Exception("No spots left");
            }
            if (_members.Contains(member))
            {
                throw new Exception("User with this ID is already in this rotation");
            }
            if (member.UserId == Creator)
            {
                throw new Exception("User cannot join his own rotation");
            }

            _members.Add(member);
            Spots = Spots - 1;
        }

        public void DeleteMember(User member)
        {
            if (member == null)
            {
                throw new Exception("Cannot delete empty user");
            }
            if (!_members.Contains(member))
            {
                throw new Exception("User does not exist in this rotation");
            }
            if (member.UserId == Creator)
            {
                throw new Exception("User cannot be from his own rotation");
            }
            
            _members.Remove(member);
            Spots = Spots + 1;
        }
    }
}