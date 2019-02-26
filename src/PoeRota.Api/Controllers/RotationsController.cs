using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoeRota.Infrastructure.Commands;
using PoeRota.Infrastructure.Commands.Rotations;
using PoeRota.Infrastructure.Commands.Users;
using PoeRota.Infrastructure.DTO;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RotationsController : ControllerBase
    {
        private readonly IRotationService _rotationService;
        private readonly ICommandDispatcher _commandDispatcher;

        public RotationsController(IRotationService rotationService, 
            ICommandDispatcher commandDispatcher)
        {
            _rotationService = rotationService;
            _commandDispatcher = commandDispatcher;
        }

        //GET /rotations
        [HttpGet]
        public async Task<IEnumerable<RotationDto>> GetAll()
            => await _rotationService.GetAllAsync();

        // GET /rotations/type
        [HttpGet("{type}")]
        public async Task<IEnumerable<RotationDto>> Get(string type)
            => await _rotationService.GetAsync(type);

        // POST /rotations/CreateRotation
        [HttpPost("create")]
        public async Task<IActionResult> CreateRotation([FromBody] CreateRotation command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok($"Created rotation with UserId : {command.UserId}");
        }

        //Post /rotations/JoinRotation
        [HttpPost("join")]
        public async Task<IActionResult> AddMemberToRotation([FromBody] JoinRotation command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok($"Added user : {command.UserId} to rotation : {command.RotationId}");
        }

        [HttpPost("leave")]
        public async Task<IActionResult> RemoveUserFromRotation([FromBody] LeaveRotation command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok($"Removed user : {command.UserId} from rotation : {command.RotationId}");
        }
    }
}
