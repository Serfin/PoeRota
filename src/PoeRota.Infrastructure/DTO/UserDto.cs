using System;

namespace PoeRota.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string League { get; set; }
        public string Ign { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}