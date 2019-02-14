using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoeRota.Core.Domain;
using PoeRota.Core.Repositories;

namespace PoeRota.Infrastructure.Repositories
{
    public class RotationRepository : IRotationRepository
    {
         private static readonly User[] _users = new User[3]
        {
            new User(Guid.NewGuid(), "user1@gmail.com", "user1", "secret", "salt", "ign1", "user"),
            new User(Guid.NewGuid(), "user2@gmail.com", "user2", "secret", "salt", "ign2", "user"),
            new User(Guid.NewGuid(), "user3@gmail.com", "user3", "secret", "salt", "ign3", "user")  
        };
        private static readonly ISet<Rotation> _rotations = new HashSet<Rotation>
        {
            new Rotation(Guid.NewGuid(), _users[0], "Delve", "masterrotation"),
            new Rotation(Guid.NewGuid(), _users[1], "Betrayal", "masterrotation"),
            new Rotation(Guid.NewGuid(), _users[2], "Delve", "maprotation"),
        };
        public async Task AddAsync(Rotation rotation)
        {
            _rotations.Add(rotation);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Rotation>> GetAllAsync()
            => await Task.FromResult(_rotations);

        public async Task<Rotation> GetAsync(Guid rotationId)
            => await Task.FromResult(_rotations.SingleOrDefault(x => x.RotationId == rotationId));

        public async Task<IEnumerable<Rotation>> GetAsync(string type)
            => await Task.FromResult(_rotations.Select(x => x).Where(x => x.Type == type));

        public async Task RemoveAsync(Guid rotationId)
        {
            var rotation = await GetAsync(rotationId);
            _rotations.Remove(rotation);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Rotation rotation)
        {
            await Task.CompletedTask;
        }
    }
}