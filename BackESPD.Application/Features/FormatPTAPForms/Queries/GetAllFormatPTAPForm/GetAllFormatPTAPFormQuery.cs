using AutoMapper;
using BackESPD.Application.DTOs.FormatPTAPForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.FormatPTAPForms.Queries.GetAllFormatPTAPForm
{
    public class GetAllFormatPTAPFormQuery : IRequest<GenericResponse<List<FormatPTAPFormDto>>>
    {
    }

    internal class GetAllFormatPTAPFormQueryHandler : IRequestHandler<GetAllFormatPTAPFormQuery, GenericResponse<List<FormatPTAPFormDto>>>
    {
        private readonly IRepositoryAsync<FormatPTAPForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllFormatPTAPFormQueryHandler(IRepositoryAsync<FormatPTAPForm> repositorioAsync, IMapper mapper)
        {
            _repositoryAsync = repositorioAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<FormatPTAPFormDto>>> Handle(GetAllFormatPTAPFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var formatPTAPFormDto = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(FormatPTAPForm.IdUserNavigation)},{nameof(FormatPTAPForm.IdPlantNavigation)}");
                return new GenericResponse<List<FormatPTAPFormDto>>(_mapper.Map<List<FormatPTAPFormDto>>(formatPTAPFormDto));
                throw new NotImplementedException();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
