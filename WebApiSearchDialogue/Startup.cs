using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebApiSearchDialogue.AppStart.Configures;
using WebApiSearchDialogue.AppStart.ConfigureServices;
using Application;
using Application.ConfigureServices;

namespace WebApiSearchDialogue
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //ConfigureServicesBase.ConfigureServices(services, Configuration);
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddApplication();

            ConfigureServicesMediatR.ConfigureServices(services);
            ConfigureServicesControllers.ConfigureServices(services);
            ConfigureServicesSwagger.ConfigureServices(services, Configuration);
            ConfigureServicesCors.ConfigureServices(services, Configuration);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ConfigureCommon.Configure(app, env);
        }
    }
}
