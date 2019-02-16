using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PoeRota.Core.Repositories;
using PoeRota.Infrastructure.CommandHandlers;
using PoeRota.Infrastructure.CommandHandlers.User;
using PoeRota.Infrastructure.Commands.Users;
using PoeRota.Infrastructure.IoC;
using PoeRota.Infrastructure.Mappers;
using PoeRota.Infrastructure.Repositories;
using PoeRota.Infrastructure.Services;
using PoeRota.Infrastructure.Settings;

namespace PoeRota.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.

        private readonly JwtSettings _jwtsettings;

        public Startup(JwtSettings jwtsettings)
        {
            _jwtsettings = jwtsettings;
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection.
            services.AddMvc();

            services.AddAuthentication().AddJwtBearer(cfg => {
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = _jwtsettings.Issuer,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.Key))
                };
            });

            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Configure is where you add middleware. This is called after
        // ConfigureServices. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(
            IApplicationBuilder app,
            ILoggerFactory loggerFactory,
            IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
