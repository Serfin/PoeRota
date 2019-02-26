using System;

namespace PoeRota.Infrastructure.Commands.Rotations
{
    public class LeaveRotation : ICommand
    {
        public Guid UserId { get; set; }
        public Guid RotationId { get; set; }
    }
}