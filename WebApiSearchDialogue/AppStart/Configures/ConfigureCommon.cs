using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebApiSearchDialogue.AppStart.ConfigureServices;
using WebApiSearchDialogue.Middleware;

namespace WebApiSearchDialogue.AppStart.Configures
{
    public class ConfigureCommon
    {
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCustomExceptionHandler();
            app.UseSwaggerUI(ConfigureServicesSwagger.SwaggerSettings);
            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(builder => builder
            .WithOrigins("https://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            );
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
