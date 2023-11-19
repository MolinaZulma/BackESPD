using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Plants.Commands.DeletePlant
{
    public class DeletePlantCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeletePlantCommandHandler : IRequestHandler<DeletePlantCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<Plant> _repositoryAsync;

        public DeletePlantCommandHandler(IRepositoryAsync<Plant> repositoryAsync )
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeletePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var plant = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (plant == null)
                    throw new KeyNotFoundException($"Planta con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(plant);
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
