using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Builder;
using System.Reflection;
using System.IO;

namespace WebApiSearchDialogue.AppStart.ConfigureServices
{
    public static class ConfigureServicesSwagger
    {
        private const string AppTitle = "Search Dialogue API ";
        private static string AppVersion = "1.0.0";
        private const string SwaggerConfig = "/swagger/v1/swagger.json";

        /// <summary>
        /// ConfigureServices Swagger services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = AppTitle,
                    Version = AppVersion,
                    Description = "Search Dialogue API module API documentation." +
                    " This API based on ASP.NET Core 5.",

                    Contact = new OpenApiContact
                    {
                        Name = "Sergei Zakharov",
                        Email = "sergeizahargood@gmail.com",
                        Url = new Uri("https://www.instagram.com/sergeizahargood_gmail_com/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MY License",
                        Url = new Uri("https://www.instagram.com/")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.ResolveConflictingActions(x => x.First());
            });
        }

        /// <summary>
        /// properties for swagger UI
        /// </summary>
        /// <param name="settings"></param>
        public static void SwaggerSettings(SwaggerUIOptions settings)
        {
            settings.SwaggerEndpoint(SwaggerConfig, $"{AppTitle} v.{AppVersion}");
            settings.DocumentTitle = "Search Dialogue API";
            settings.DefaultModelExpandDepth(0);
            settings.DefaultModelRendering(ModelRendering.Model);
            settings.DefaultModelsExpandDepth(0);
            settings.DocExpansion(DocExpansion.None);
            settings.DisplayRequestDuration();
        }
    }
}
