using Autofac;
using Microsoft.Extensions.Configuration;
using PoeRota.Infrastructure.Extensions;
using PoeRota.Infrastructure.Settings;

namespace PoeRota.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                   .SingleInstance();
		}  
    }
}