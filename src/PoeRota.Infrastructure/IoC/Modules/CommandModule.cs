using System.Reflection;
using Autofac;
using PoeRota.Infrastructure.CommandHandlers;
using PoeRota.Infrastructure.CommandHandlers.User;
using PoeRota.Infrastructure.Commands;
using PoeRota.Infrastructure.Commands.Users;

namespace PoeRota.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                    .GetTypeInfo()
                    .Assembly;
            
            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                   .As<ICommandDispatcher>()
                   .InstancePerLifetimeScope();
        }
    }
}