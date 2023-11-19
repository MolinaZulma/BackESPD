using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.JarFormatForms.Queries.GetAllJarFormatForm
{
    public class GetAllJarFormatFormQuery : IRequest<GenericResponse<List<JarFormatFormDto>>>
    {
    }

    internal class GetAllJarFormatFormQueryHandler : IRequestHandler<GetAllJarFormatFormQuery, GenericResponse<List<JarFormatFormDto>>>
    {
        private readonly IRepositoryAsync<JarFormatForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllJarFormatFormQueryHandler(IRepositoryAsync<JarFormatForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<List<JarFormatFormDto>>> Handle(GetAllJarFormatFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var jarFormatForm = await _repositoryAsync.GetAllAsync(includeProperties: $"{nameof(JarFormatForm.IdUserNavigation)},{nameof(JarFormatForm.IdPlantNavigation)}");
                return new GenericResponse<List<JarFormatFormDto>>(_mapper.Map<List<JarFormatFormDto>>(jarFormatForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
