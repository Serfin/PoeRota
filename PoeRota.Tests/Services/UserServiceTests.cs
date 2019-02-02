using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PoeRota.Infrastructure.Services;
using PoeRota.Core.Repositories;
using AutoMapper;
using PoeRota.Core.Domain;

namespace PoeRota.Tests.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public async Task register_async_should_invoke_add_assync_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            await userService.RegisterAsync("user1","password","user1@gmail.com","ign1");
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}