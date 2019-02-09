using System.Threading.Tasks;
using System;
using Moq;
using NUnit.Framework;
using PoeRota.Core.Repositories;
using AutoMapper;
using PoeRota.Core.Domain;
using PoeRota.Infrastructure.Services;

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

            await userService.RegisterAsync("user1", "password", "user1@gmail.com", "ign1");
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task when_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.GetAsync("user1@email.com"); // Invoke userService -> userRepo
            
            var user = new User(Guid.NewGuid(), "user1@email.com", "secret", "user", "salt", "ign", "league");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user); // Check if return type == User

            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}