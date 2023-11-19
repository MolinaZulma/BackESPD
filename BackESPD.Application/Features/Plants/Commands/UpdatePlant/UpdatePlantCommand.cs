using AutoMapper;
using BackESPD.Application.DTOs.Plant;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Plants.Commands.UpdatePlant
{
    public class UpdatePlantCommand : IRequest<GenericResponse<PlantDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypePlant { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
    }

    internal class UpdatePlantCommandHandler : IRequestHandler<UpdatePlantCommand, GenericResponse<PlantDto>>
    {
        private readonly IRepositoryAsync<Plant> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdatePlantCommandHandler(IRepositoryAsync<Plant> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<PlantDto>> Handle(UpdatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var plant = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (plant == null)
                    throw new KeyNotFoundException($"Plant con el id: {request.Id} no existe");

                plant.Name = request.Name;
                plant.TypePlant = request.TypePlant;
                plant.Direction = request.Direction;
                plant.Description  = request.Description;

                await _repositoryAsync.UpdateAsync(plant);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<PlantDto>(_mapper.Map<PlantDto>(plant));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
