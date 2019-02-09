using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PoeRota.Core.Domain;
using PoeRota.Core.Repositories;
using PoeRota.Infrastructure.DTO;

namespace PoeRota.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users); 
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string username, string password, 
            string email, string ign)
        {
            var user = await _userRepository.GetAsync(email);

            if ( user != null)
            {
                throw new Exception($"User with email: {email} already exists.");
            }

            user = new User(Guid.NewGuid(), email, username, password, "salt", ign, "league");
            await _userRepository.AddAsync(user);
        }
    }
}