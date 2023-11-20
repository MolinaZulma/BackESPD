using AutoMapper;
using BackESPD.Application.DTOs.WaterControlForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.WaterControlForms.Queries.GetByIdWaterControlForm
{
    public class GetByIdWaterControlFormQuery : IRequest<GenericResponse<WaterControlFormDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdWaterControlFormQueryHandler : IRequestHandler<GetByIdWaterControlFormQuery, GenericResponse<WaterControlFormDto>>
    {
        private readonly IRepositoryAsync<WaterControlForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdWaterControlFormQueryHandler(IRepositoryAsync<WaterControlForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<WaterControlFormDto>> Handle(GetByIdWaterControlFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var waterControlForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (waterControlForm == null)
                    throw new KeyNotFoundException($"WaterControlForm con el id: {request.Id} no existe");

                return new GenericResponse<WaterControlFormDto>(_mapper.Map<WaterControlFormDto>(waterControlForm));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
