using AutoMapper;
using BackESPD.Application.DTOs.ActivityLogsForm;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.DTOs.Plant;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.Features.ActivityLogsForms.Commands.CreateActivityLogsForm;
using BackESPD.Application.Features.DamageReports.Commands.CreateDamageReport;
using BackESPD.Application.Features.Plants.Commands.CreatePlant;
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

            //CreateMap<ActivityLogsForm, ActivityLogsFormDto>()
            //    .ForMember(damageReport => damageReport.userFullName, options => options.MapFrom(origin => origin.IdUserNavigation.FullName));
            CreateMap<CreateActivityLogsFormCommand, ActivityLogsForm>();

            #region Plant
            CreateMap<Plant, PlantDto>().ReverseMap();
            CreateMap<CreatePlantCommand, Plant>();
            #endregion
        }
    }
}
