using System;
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
        private readonly IRotationRepository _rotations;
        private readonly IUserRepository _users;
        private readonly IMapper _mapper;

        public RotationService(IRotationRepository rotations, IUserRepository users, 
            IMapper mapper)
        {
            _rotations = rotations;
            _users = users;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RotationDto>> GetAllAsync()
        {
            var rotations = await _rotations.GetAllAsync();

            return _mapper.Map<IEnumerable<Rotation>, IEnumerable<RotationDto>>(rotations);
        }

        public async Task<IEnumerable<RotationDto>> GetAsync(string type)
        {
            var rotations = await _rotations.GetAsync(type);

            return _mapper.Map<IEnumerable<Rotation>, IEnumerable<RotationDto>>(rotations);
        }

        public async Task AddAsync(Guid rotationId, Guid user, string league, string type, int spots)
        {
            var rotation = new Rotation(rotationId, user, league, type, spots);
            
            await _rotations.AddAsync(rotation);    
        }

        public async Task AddMemeberAsync(Guid userId, Guid rotationId)
        {
            var userRepo = await _users.GetAsync(userId);
            if (userRepo == null)
            {
                throw new Exception("User with this ID does not exist");
            }

            var rotation = await _rotations.GetAsync(rotationId);
            if (rotation == null)
            {
                throw new Exception("Rotation with tihs ID does not exist");
            }

            rotation.AddMember(userRepo);
        }

        public async Task DeleteMemberAsync(Guid userId, Guid rotationId)
        {
            var userRepo = await _users.GetAsync(userId);
            if (userRepo == null)
            {
                throw new Exception("User with this ID does not exist");
            }

            var rotation = await _rotations.GetAsync(rotationId);
            if (rotation == null)
            {
                throw new Exception("Rotation with tihs ID does not exist");
            }

            rotation.DeleteMember(userRepo);
        }
    }
}