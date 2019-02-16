using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoeRota.Infrastructure.Commands;
using PoeRota.Infrastructure.Commands.Accounts;

namespace PoeRota.Api.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public LoginController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login command)
        {
            await _commandDispatcher.DispatchAsync(command);

            return Ok("Login successful");
        }
    }
}