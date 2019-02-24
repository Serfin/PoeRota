using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoeRota.Infrastructure.Services;
using PoeRota.Infrastructure.Settings;

namespace PoeRota.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Message()
        {
            string message = "Available paths : \n / \n /users \n /users/(email) \n /users/(CreateUser) \n /rotations \n /rotations/(type) \n /rotations/(CreateRotation) \n";
            await Task.CompletedTask;

            return Ok(message);
        }
    }
}