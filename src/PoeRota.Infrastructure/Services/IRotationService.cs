using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoeRota.Core.Domain;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public interface IRotationService : IService
    {
        Task<IEnumerable<RotationDto>> GetAllAsync();
        Task<IEnumerable<RotationDto>> GetAsync(string type);
        Task AddAsync(Guid rotationId, Guid user, string league, string type, int spots);
        Task AddMemeberAsync(Guid userId, Guid rotationId);
        Task DeleteMemberAsync(Guid userId, Guid rotationId);
    }
}