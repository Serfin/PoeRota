using System;
using System.Threading.Tasks;
using PoeRota.Core.Repositories;
using PoeRota.Infrastructure.Commands.Accounts;
using PoeRota.Infrastructure.DTO;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Infrastructure.CommandHandlers.Account
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
        }
        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.GetToken(user.UserId, user.Role);
            Console.WriteLine(jwt.Token + "\n" + jwt.Expires);
        }
    }
}