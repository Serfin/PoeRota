using System.Reflection;
using Autofac;
using PoeRota.Core.Repositories;
using PoeRota.Infrastructure.Repositories;
using PoeRota.Infrastructure.Services;

namespace PoeRota.Infrastructure.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;
           
            builder.RegisterAssemblyTypes(assembly)
                   .Where(x => x.IsAssignableTo<IRepository>())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}