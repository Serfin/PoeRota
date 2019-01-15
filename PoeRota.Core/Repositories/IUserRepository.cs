using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoeRota.Core.Domain;

namespace PoeRota.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid userId);
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid userId);
    }
}