using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApiSearchDialogue.AppStart.ConfigureServices
{
    /// <summary>
    /// Cors configurations
    /// </summary>
    public class ConfigureServicesCors
    {
        /// <summary>
        /// Configure Services Cors
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            /*            services.AddCors(options =>
                        {
                            options.AddPolicy("CorsPolicy", builder =>
                            {
                                builder.AllowAnyHeader();
                                builder.AllowAnyMethod();
                                builder.WithOrigins("http://localhost:4200");
                                builder.AllowCredentials();
                            });
                        });
            */
        }
    }
}