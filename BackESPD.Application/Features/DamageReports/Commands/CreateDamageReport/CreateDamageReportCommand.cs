using AutoMapper;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.DamageReports.Commands.CreateDamageReport
{
    public class CreateDamageReportCommand : IRequest<GenericResponse<DamageReportDto>>
    {
        public string AddressDamage { get; set; }
        public string DescriptionDamage { get; set; }
        public string Image { get; set; }
        public string TrueInformation { get; set; }
        public string TypeDamage { get; set; }
        public string IdUser { get; set; }
    }

    internal class CreateDamageReportCommandHandler : IRequestHandler<CreateDamageReportCommand, GenericResponse<DamageReportDto>>
    {
        private readonly IRepositoryAsync<DamageReport> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateDamageReportCommandHandler(IRepositoryAsync<DamageReport> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<DamageReportDto>> Handle(CreateDamageReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DamageReport newDamageReport = _mapper.Map<CreateDamageReportCommand, DamageReport>(request);
                var damageReport = await _repositoryAsync.CreateAsync(newDamageReport);
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
