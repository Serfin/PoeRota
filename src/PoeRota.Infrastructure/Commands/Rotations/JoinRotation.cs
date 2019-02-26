using System;

namespace PoeRota.Infrastructure.Commands.Rotations
{
    public class JoinRotation : ICommand
    {
        public Guid UserId { get; set; }
        public Guid RotationId { get; set; }
    }
}