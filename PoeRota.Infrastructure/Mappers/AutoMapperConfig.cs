using AutoMapper;
using PoeRota.Core.Domain;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<User, UserDto>();
            })
            .CreateMapper();
    }
}