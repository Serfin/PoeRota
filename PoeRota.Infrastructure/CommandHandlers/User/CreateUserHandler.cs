using System.Threading.Tasks;
using PoeRota.Infrastructure.Commands.Users;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Infrastructure.CommandHandlers.User
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Username, command.Password,
                command.Email, command.Ign);
        }
    }
}