using Autofac;
using Microsoft.Extensions.Configuration;
using PoeRota.Infrastructure.IoC.Modules;
using PoeRota.Infrastructure.Mappers;

namespace PoeRota.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            
            builder.RegisterModule(new SettingsModule(_configuration));

            builder.RegisterInstance(AutoMapperConfig.Initialize())
                   .SingleInstance();
        }
    }
}