using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoeRota.Infrastructure.Commands.Users;
using PoeRota.Infrastructure.DTO;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GET users
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
            => await _userService.GetAllAsync();

        // GET users/id
        [HttpGet("{email}")]
        public async Task<UserDto> Get(string email)
            => await _userService.GetAsync(email);

        [HttpPost]
        public async Task Register([FromBody] CreateUser request)
            => await _userService.RegisterAsync(request.Username, 
            request.Password, request.Email, request.Ign);
    }
}
