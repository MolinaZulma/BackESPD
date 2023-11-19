using AutoMapper;
using BackESPD.Application.DTOs.Plant;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Plants.Queries.GetByIdPlant
{
    public class GetByIdPlantQuery : IRequest<GenericResponse<PlantDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdPlantQueryHandler : IRequestHandler<GetByIdPlantQuery, GenericResponse<PlantDto>>
    {
        private readonly IRepositoryAsync<Plant> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdPlantQueryHandler(IRepositoryAsync<Plant> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<PlantDto>> Handle(GetByIdPlantQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var plant = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (plant == null)
                    throw new KeyNotFoundException($"Plant con el id: {request.Id} no existe");

                return new GenericResponse<PlantDto>(_mapper.Map<PlantDto>(plant));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
