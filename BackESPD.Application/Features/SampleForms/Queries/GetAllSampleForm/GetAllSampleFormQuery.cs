using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.DTOs.SampleForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.SampleForms.Queries.GetAllSampleForm
{
    public class GetAllSampleFormQuery : IRequest<GenericResponse<List<SampleFormDto>>>
    {
    }

    internal class GetAllSampleFormQueryHandler : IRequestHandler<GetAllSampleFormQuery, GenericResponse<List<SampleFormDto>>>
    {
        private readonly IRepositoryAsync<SampleForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllSampleFormQueryHandler(IRepositoryAsync<SampleForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<SampleFormDto>>> Handle(GetAllSampleFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sampleForm = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(SampleForm.IdUserNavigation)},{nameof(SampleForm.IdPlantNavigation)}");
                return new GenericResponse<List<SampleFormDto>>(_mapper.Map<List<SampleFormDto>>(sampleForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
