using AutoMapper;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Features.DamageReports.Commands.CreateDamageReport;
using BackESPD.Domain.Entities;

namespace BackESPD.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<DamageReport, DamageReportDto>()
                .ForMember(damageReport => damageReport.userFullName, options => options.MapFrom(origin => origin.IdUserNavigation.FullName));            
            CreateMap<CreateDamageReportCommand, DamageReport>();

            CreateMap<User, UserListDTO>().ReverseMap();
        }
    }
}
