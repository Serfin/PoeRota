using System.Threading.Tasks;
using PoeRota.Infrastructure.Commands;

namespace PoeRota.Infrastructure.CommandHandlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}