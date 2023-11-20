using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
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

namespace BackESPD.Application.Features.WaterControlForms.Queries.GetAllWaterControlForm
{
    public class GetAllWaterControlFormQuery : IRequest<GenericResponse<List<WaterControlFormDto>>>
    {
    }

    internal class GetAllWaterControlFormQueryHandler : IRequestHandler<GetAllWaterControlFormQuery, GenericResponse<List<WaterControlFormDto>>>
    {
        private readonly IRepositoryAsync<WaterControlForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllWaterControlFormQueryHandler(IRepositoryAsync<WaterControlForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<WaterControlFormDto>>> Handle(GetAllWaterControlFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var waterControlForm = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(WaterControlForm.IdUserNavigation)},{nameof(WaterControlForm.IdPlantNavigation)}");
                return new GenericResponse<List<WaterControlFormDto>>(_mapper.Map<List<WaterControlFormDto>>(waterControlForm));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
