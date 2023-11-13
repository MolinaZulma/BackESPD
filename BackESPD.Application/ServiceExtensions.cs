using AutoMapper;
using BackESPD.Application.Behaviours;
using BackESPD.Application.Mappings;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackESPD.Application
{
    public static class ServiceExtensions
    {
        public static void AddIOCApplicationLayer(this IServiceCollection services)
        {            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(p => p.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            // Configuración de AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GeneralProfile>(); // Agregar el perfil GeneralProfile que esta en Mappings
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
