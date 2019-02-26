using System.Threading.Tasks;
using PoeRota.Infrastructure.Commands.Rotations;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Infrastructure.CommandHandlers.Rotation
{
    public class JoinRotationHandler : ICommandHandler<JoinRotation>
    {
        private readonly IRotationService _rotationService;

        public JoinRotationHandler(IRotationService rotationService)
        {
            _rotationService = rotationService;
        }
        public async Task HandleAsync(JoinRotation command)
        {
            await _rotationService.AddMemeberAsync(command.UserId, command.RotationId);
        }
    }
}