using AutoMapper;
using BackESPD.Application.DTOs.ActivityLogsForm;
using BackESPD.Application.DTOs.AspNetRoles;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.DTOs.FormatPTAPForm;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.DTOs.Plant;
using BackESPD.Application.DTOs.SampleForm;
using BackESPD.Application.DTOs.Users;
using BackESPD.Application.DTOs.WaterControlForm;
using BackESPD.Application.Features.ActivityLogsForms.Commands.CreateActivityLogsForm;
using BackESPD.Application.Features.DamageReports.Commands.CreateDamageReport;
using BackESPD.Application.Features.FormatPTAPForms.Commands.CreateFormatPTAPForm;
using BackESPD.Application.Features.JarFormatForms.Commands.CreateJarFormatForm;
using BackESPD.Application.Features.Plants.Commands.CreatePlant;
using BackESPD.Application.Features.SampleForms.Commands.CreateSampleForm;
using BackESPD.Application.Features.WaterControlForms.Commands.CreateWaterControlForm;
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

            #region ActivityLogsForm
            CreateMap<ActivityLogsForm, ActivityLogsFormDto>()
            .ForMember(activityLogsForm => activityLogsForm.UserFullName, options => options.MapFrom(origin => origin.IdUserNavigation.FullName))
            .ForMember(activityLogsForm => activityLogsForm.NamePlant, options => options.MapFrom(origin => origin.IdPlantNavigation.Name));




            CreateMap<ActivityLogsForm, ActivityLogsFormDto>().ReverseMap();
            CreateMap<CreateActivityLogsFormCommand, ActivityLogsForm>();
            #endregion

            #region Plant
            CreateMap<Plant, PlantDto>().ReverseMap();
            CreateMap<CreatePlantCommand, Plant>();
            #endregion

            #region FormatPTAPForm
            CreateMap<FormatPTAPForm, FormatPTAPFormDto>().ReverseMap();
            CreateMap<CreateFormatPTAPFormCommand, FormatPTAPForm>();
            #endregion


            #region JarFormatForm
            CreateMap<JarFormatForm, JarFormatFormDto>().ReverseMap();
            CreateMap<CreateJarFormatFormCommand, JarFormatForm>();
            #endregion

            #region SampleForm
            CreateMap<SampleForm, SampleFormDto>().ReverseMap();
            CreateMap<CreateSampleFormCommand, SampleForm>();
            #endregion

            #region WaterControlForm
            CreateMap<WaterControlForm, WaterControlFormDto>().ReverseMap();
            CreateMap<CreateWaterControlFormCommand, WaterControlForm>();
            #endregion

            #region AspNetRoles
            CreateMap<Roles, AspNetRolesDto>().ReverseMap();
            //CreateMap<CreateWaterControlFormCommand, WaterControlForm>();
            #endregion

        }
    }
}
