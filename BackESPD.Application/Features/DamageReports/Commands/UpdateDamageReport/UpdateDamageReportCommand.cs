using AutoMapper;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.DamageReports.Commands.UpdateDamageReport
{
    public class UpdateDamageReportCommand : IRequest<GenericResponse<DamageReportDto>>
    {
        public int Id { get; set; }
        public string AddressDamage { get; set; }
        public string DescriptionDamage { get; set; }
        public string Image { get; set; }
        public string TrueInformation { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string TypeDamage { get; set; }
    }

    internal class UpdateDamageReportCommandHandler : IRequestHandler<UpdateDamageReportCommand, GenericResponse<DamageReportDto>>
    {
        private readonly IRepositoryAsync<DamageReport> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateDamageReportCommandHandler(IRepositoryAsync<DamageReport> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<DamageReportDto>> Handle(UpdateDamageReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var damageReport = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (damageReport == null)
                    throw new KeyNotFoundException($"Reporte de daño con el id: {request.Id} no existe");

                    damageReport.AddressDamage = request.AddressDamage;
                    damageReport.DescriptionDamage = request.DescriptionDamage;
                    damageReport.Image = request.Image;
                    damageReport.TrueInformation = request.TrueInformation;
                    damageReport.TypeDamage = request.TypeDamage;
                    damageReport.NationalIdentificationNumber = request.NationalIdentificationNumber;

                await _repositoryAsync.UpdateAsync(damageReport);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<DamageReportDto>(_mapper.Map<DamageReportDto>(damageReport));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
