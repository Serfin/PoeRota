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
    public class RotationController : ControllerBase
    {
        private readonly IRotationService _rotationService;

        public RotationController(IRotationService rotationService)
        {
            _rotationService = rotationService;
        }

        //GET rotations
        [HttpGet]
        public async Task<IEnumerable<RotationDto>> GetAll()
            => await _rotationService.GetAllAsync();

        // GET rotations/type
        [HttpGet("{type}")]
        public async Task<IEnumerable<RotationDto>> Get(string type)
            => await _rotationService.GetAsync(type);
    }
}
