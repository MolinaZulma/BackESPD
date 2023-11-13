using BackESPD.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BackESPD.Shared
{
    public static class ServicesExtenisions
    {
        public static void AddIOCSharedLayer(this IServiceCollection services)
        {
            #region Services

            services.AddTransient<IDateTimeService, DateTimeService.DateTimeService>();
            #endregion
        }
    }
}
