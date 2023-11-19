using AutoMapper;
using BackESPD.Application.DTOs.FormatPTAPForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.FormatPTAPForms.Queries.GetByIdFormatPTAPForm
{
    public class GetByIdFormatPTAPFormQuery : IRequest<GenericResponse<FormatPTAPFormDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdFormatPTAPFormQueryHandler : IRequestHandler<GetByIdFormatPTAPFormQuery, GenericResponse<FormatPTAPFormDto>>
    {
        private readonly IRepositoryAsync<FormatPTAPForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdFormatPTAPFormQueryHandler(IRepositoryAsync<FormatPTAPForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<FormatPTAPFormDto>> Handle(GetByIdFormatPTAPFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var formatPTAPForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (formatPTAPForm == null)
                    throw new KeyNotFoundException($"FormatPTAPForm con el id: {request.Id} no existe");

                return new GenericResponse<FormatPTAPFormDto>(_mapper.Map<FormatPTAPFormDto>(formatPTAPForm));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
