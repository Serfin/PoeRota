using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace PoeRota.Tests.EndToEnd.Controllers
{
    // WON'T WORK UNTIL MIGRATE TO NETCORE 2.1
    // [TestFixture]
    // public class RotationsControllerTest
    // {
    //     private readonly TestServer _server;
    //     private readonly HttpClient _client;

    //     protected RotationsControllerTest()
    //     {
    //         _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
    //         _client = _server.CreateClient();
    //     }

    //     [Test]
    //     public async Task given_invalid_rotation_type_should_not_exist()
    //     {
    //         var rotationType = "mappprotation";
    //         var response = await _client.GetAsync($"rotations/{rotationType}");
    //         response.StatusCode.Equals(HttpStatusCode.NotFound);
    //     }        
    // }
}