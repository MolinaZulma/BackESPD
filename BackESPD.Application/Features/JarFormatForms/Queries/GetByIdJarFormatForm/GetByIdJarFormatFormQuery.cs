using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.JarFormatForms.Queries.GetByIdJarFormatForm
{
    public class GetByIdJarFormatFormQuery : IRequest<GenericResponse<JarFormatFormDto>>
    {
        public int Id { get; set; }
    }

    internal class GetByIdJarFormatFormQueryHandler : IRequestHandler<GetByIdJarFormatFormQuery, GenericResponse<JarFormatFormDto>>
    {
        private readonly IRepositoryAsync<JarFormatForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetByIdJarFormatFormQueryHandler(IRepositoryAsync<JarFormatForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<JarFormatFormDto>> Handle(GetByIdJarFormatFormQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var jarFormatForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (jarFormatForm == null)
                    throw new KeyNotFoundException($"JarFormatForm con el id: {request.Id} no existe");

                return new GenericResponse<JarFormatFormDto>(_mapper.Map<JarFormatFormDto>(jarFormatForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
