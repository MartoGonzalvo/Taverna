using ControlPortales.Infraestructure.Services.Services.Config;
using ControlPortales.Infraestructure.Services.Services.Notifications;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlPortales.Infraestructure.Services
{
    public static class DependencyInjections
    {
        public static void AddNotificationsService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddHttpClient<INotificationsService, NotificationsService>(client =>
             {
                 client.BaseAddress = new Uri($"{configuration.GetSection(ApiUrls.Position).GetSection(ApiUrls.NotificationsApi).Value}/v1/{ApiController.Notifications}/");
                 client.DefaultRequestHeaders.Add("User-Agent", configuration["AppSettings:UserAgent"]);
             });
        }
    }
}
