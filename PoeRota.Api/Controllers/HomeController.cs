using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace PoeRota.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Message()
        {
            return "Available paths : \n / \n /users \n /users/(email) \n /rotations \n /rotations/(type)";
        }
    }
}