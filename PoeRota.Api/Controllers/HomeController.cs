using Microsoft.AspNetCore.Mvc;

namespace PoeRota.Api.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public string Message()
        {
            return "PoeRota v.0.0.1";
        }
    }
}