using System;

namespace PoeRota.Infrastructure.DTO
{
    public class RotationDto
    {
        public Guid RotationId {get; set; }
        public UserDto Creator { get; set; }
        public string League { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}