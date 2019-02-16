using System;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDto GetToken(Guid userId, string role);
    }
}