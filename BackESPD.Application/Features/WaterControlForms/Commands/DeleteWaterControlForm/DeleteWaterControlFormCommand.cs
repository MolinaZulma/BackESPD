using BackESPD.Application.DTOs.WaterControlForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackESPD.Application.Features.WaterControlForms.Commands.DeleteWaterControlForm
{
    public class DeleteWaterControlFormCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteWaterControlFormCommandHandler : IRequestHandler<DeleteWaterControlFormCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<WaterControlForm> _repositoryAsync;

        public DeleteWaterControlFormCommandHandler(IRepositoryAsync<WaterControlForm> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteWaterControlFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var waterControlForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (waterControlForm == null)
                    throw new KeyNotFoundException($"WaterControlForm con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(waterControlForm);
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
