using AutoMapper;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.DamageReports.Querys.GetByIdDamageReport
{
    public class GetByIdDamageReportQuery : IRequest<GenericResponse<DamageReportDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdDamageReportQueryHandler : IRequestHandler<GetByIdDamageReportQuery, GenericResponse<DamageReportDto>>
    {
        private readonly IRepositoryAsync<DamageReport> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdDamageReportQueryHandler(IRepositoryAsync<DamageReport> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<GenericResponse<DamageReportDto>> Handle(GetByIdDamageReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var damageReport = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id, includeProperties: $"{nameof(DamageReport.IdUserNavigation)}");
                if (damageReport == null)
                    throw new KeyNotFoundException($"Reporte de daño con el id: {request.Id} no existe");

                return new GenericResponse<DamageReportDto>(_mapper.Map<DamageReportDto>(damageReport));

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
