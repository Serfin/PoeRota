using System.Collections.Generic;
using System.Threading.Tasks;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public interface IRotationService : IService
    {
        Task<IEnumerable<RotationDto>> GetAllAsync();
        Task<IEnumerable<RotationDto>> GetAsync(string type);
    }
}