using AutoMapper;
using BackESPD.Application.DTOs.Plant;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Plants.Commands.CreatePlant
{
    public class CreatePlantCommand : IRequest<GenericResponse<PlantDto>>
    {
        public string Name { get; set; }
        public string TypePlant { get; set; }
        public string Direction { get; set; }
        public string Description { get; set; }
    }

    internal class CreatePlantCommandHandler : IRequestHandler<CreatePlantCommand, GenericResponse<PlantDto>>
    {

        private readonly IRepositoryAsync<Plant> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreatePlantCommandHandler(IRepositoryAsync<Plant> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<PlantDto>> Handle(CreatePlantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Plant newPlant = _mapper.Map<CreatePlantCommand, Plant>(request);
                var plant = await _repositoryAsync.CreateAsync(newPlant);
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
