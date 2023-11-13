using AutoMapper;
using BackESPD.Application.DTOs.DamageReport;
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
            //CreateMap<DamageReport, DamageReportDto>().ReverseMap();
            CreateMap<CreateDamageReportCommand, DamageReport>();
        }
    }
}
