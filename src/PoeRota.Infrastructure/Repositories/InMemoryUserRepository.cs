using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoeRota.Core.Domain;
using PoeRota.Core.Repositories;

namespace PoeRota.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
            new User(Guid.NewGuid(), "user1@gmail.com", "user1", "secret", "salt", "ign1", "user"),
            new User(Guid.NewGuid(), "user2@gmail.com", "user2", "secret", "salt", "ign2", "user"),
            new User(Guid.NewGuid(), "user3@gmail.com", "user3", "secret", "salt", "ign3", "user")  
        };

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task<User> GetAsync(Guid userId)
            => await Task.FromResult(_users.SingleOrDefault(x => x.UserId == userId));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task RemoveAsync(Guid userId)
        {
            var user = await GetAsync(userId);
            _users.Remove(user);
            await Task.CompletedTask;
        }
        
        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}