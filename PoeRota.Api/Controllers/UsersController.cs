using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
