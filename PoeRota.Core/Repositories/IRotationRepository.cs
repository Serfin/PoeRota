using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoeRota.Core.Domain;

namespace PoeRota.Core.Repositories
{
    public interface IRotationRepository : IRepository
    {
        Task<Rotation> GetAsync(Guid rotationId);
        Task<IEnumerable<Rotation>> GetAllAsync();
        Task AddAsync(Rotation rotation);
        Task UpdateAsync(Rotation rotation);
        Task RemoveAsync(Guid rotationId);
    }
}