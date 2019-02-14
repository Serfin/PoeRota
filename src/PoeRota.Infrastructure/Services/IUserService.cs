using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task RegisterAsync(Guid userId, string username, string password, string email, string ign, string role);
        Task LoginAsync(string email, string password);
    }
}