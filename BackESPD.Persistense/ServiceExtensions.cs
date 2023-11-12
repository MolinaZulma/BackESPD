using BackESPD.Persistense.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackESPD.Persistense
{
    public static class ServiceExtensions
    {
        public static void AddIOCPersintenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BackESPDDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BackESPDDbConnection"),
               p => p.MigrationsAssembly(typeof(BackESPDDbContext).Assembly.FullName)));
        }
    }
}
