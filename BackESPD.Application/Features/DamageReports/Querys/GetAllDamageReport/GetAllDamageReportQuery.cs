using AutoMapper;
using BackESPD.Application.DTOs.DamageReport;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.DamageReports.Querys.GetAllDamageReport
{
    public class GetAllDamageReportQuery : IRequest<GenericResponse<List<DamageReportDto>>>
    {
    }

    internal class GetAllDamageReportQueryHandler : IRequestHandler<GetAllDamageReportQuery, GenericResponse<List<DamageReportDto>>>
    {
        private readonly IRepositoryAsync<DamageReport> _repositorioAsync;
        private readonly IMapper _mapper;

        public GetAllDamageReportQueryHandler(IRepositoryAsync<DamageReport> repositorioAsync, IMapper mapper)
        {
            _repositorioAsync = repositorioAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<DamageReportDto>>> Handle(GetAllDamageReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var damageReport = await _repositorioAsync.GetAllAsync(includeProperties: $"{nameof(DamageReport.IdUserNavigation)}");
                return new GenericResponse<List<DamageReportDto>>(_mapper.Map<List<DamageReportDto>>(damageReport));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
