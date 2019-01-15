using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task RegisterAsync(string username, string password, string email, string ign);
    }
}