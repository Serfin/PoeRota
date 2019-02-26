using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using PoeRota.Core.Repositories;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Tests.Services
{
    [TestFixture]
    public class RotationServiceTests
    {
        [Test]
        public async Task get_all_async_should_invoke_get_all_async_on_rotation_repository()
        {
            var repositoryMock = new Mock<IRotationRepository>();
            var mapperMock = new Mock<IMapper>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var rotationService = new RotationService(repositoryMock.Object, userRepositoryMock.Object,
                 mapperMock.Object);

            await rotationService.GetAllAsync();

            repositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
        }
    }
}