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
        public async Task calling_register_async_should_invoke_user_repository_add_assync()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);

            await userService.RegisterAsync(Guid.NewGuid(), "user1", "password", "user1@gmail.com", "ign1", "user");
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task calling_get_async_and_user_exists_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);
            await userService.GetAsync("user1@email.com"); 
            
            var user = new User(Guid.NewGuid(), "user1@email.com", "secret", "user", "salt", "ign", "user");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user); 
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public async Task calling_get_async_and_user_does_not_exists_should_ivoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);
            await userService.GetAsync("user1@gmail.com");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }
    }
}