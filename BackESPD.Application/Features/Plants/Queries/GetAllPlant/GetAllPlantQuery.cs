using AutoMapper;
using BackESPD.Application.DTOs.Plant;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Plants.Queries.GetAllPlant
{
    public class GetAllPlantQuery : IRequest<GenericResponse<List<PlantDto>>>
    {
    }

    internal class GetAllPlantQueryHandler : IRequestHandler<GetAllPlantQuery, GenericResponse<List<PlantDto>>>
    {
        private readonly IRepositoryAsync<Plant> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllPlantQueryHandler(IRepositoryAsync<Plant> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<PlantDto>>> Handle(GetAllPlantQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var plant = await _repositoryAsync.GetAllAsync();
                return new GenericResponse<List<PlantDto>>(_mapper.Map<List<PlantDto>>(plant));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
