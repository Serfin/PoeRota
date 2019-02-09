using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PoeRota.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Message()
        {
            string message = "Available paths : \n / \n /users \n /users/(email) \n /rotations \n /rotations/(type)";
            await Task.CompletedTask;
            return Ok(message);
        }
    }
}