using BackESPD.Application.Interfaces;
using BackESPD.Domain.Entities;
using BackESPD.Persistense.DbContext;
using BackESPD.Persistense.Repositories;
using Microsoft.AspNetCore.Identity;
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

            #region Repositories
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(GenericRepository<>));
            #endregion


            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ParqueDbContext>().AddDefaultTokenProviders();

            //#region Services
            //services.AddTransient<IAccountService, AccountService>();
            //#endregion
        }
    }
}
