using AutoMapper;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.DamageReports.Commands.DeleteteDamageReport
{
    public class DeleteteDamageReportCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }

    }

    internal class DeleteteDamageReportCommandHandler : IRequestHandler<DeleteteDamageReportCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<DamageReport> _repositoryAsync;

        public DeleteteDamageReportCommandHandler(IRepositoryAsync<DamageReport> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }
        public async Task<GenericResponse<bool>> Handle(DeleteteDamageReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var damageReport = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (damageReport == null)
                    throw new KeyNotFoundException($"Reporte de daño con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(damageReport);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
