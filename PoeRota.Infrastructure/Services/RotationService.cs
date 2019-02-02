using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PoeRota.Core.Domain;
using PoeRota.Core.Repositories;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public class RotationService : IRotationService
    {
        private readonly IRotationRepository _rotation;
        private readonly IMapper _mapper;

        public RotationService(IRotationRepository rotation, IMapper mapper)
        {
            _rotation = rotation;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RotationDto>> GetAllAsync()
        {
            var rotations = await _rotation.GetAllAsync();

            return _mapper.Map<IEnumerable<Rotation>, IEnumerable<RotationDto>>(rotations);
        }

        public async Task<IEnumerable<RotationDto>> GetAsync(string type)
        {
            var rotation = await _rotation.GetAsync(type);

            return _mapper.Map<IEnumerable<Rotation>, IEnumerable<RotationDto>>(rotation);
        }
    }
}