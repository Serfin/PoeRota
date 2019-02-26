using System.Threading.Tasks;
using PoeRota.Infrastructure.Commands.Rotations;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Infrastructure.CommandHandlers.Rotation
{
    public class LeaveRotationHandler : ICommandHandler<LeaveRotation>
    {
        private readonly IRotationService _rotationService;
        public LeaveRotationHandler(IRotationService rotationService)
        {
            _rotationService = rotationService;
        }

        public async Task HandleAsync(LeaveRotation command)
        {
            await _rotationService.DeleteMemberAsync(command.UserId, command.RotationId);
        }
    }
}