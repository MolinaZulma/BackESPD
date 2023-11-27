using BackESPD.Application.Interfaces;
using BackESPD.SendEmail.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackESPD.SendEmail
{
    public static class ServiceExtension
    {
        public static void AddIOCSendEmailLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISendEmail, SendEmailService>();
        }
    }
}
