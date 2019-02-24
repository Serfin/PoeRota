using System;
using PoeRota.Core.Domain;

namespace PoeRota.Infrastructure.Commands.Rotations
{
    public class CreateRotation : ICommand
    {
        public Guid UserId { get; set; }
        public string League { get; set; }
        public string Type { get; set; }
        public int Spots { get; set; }
    }
}