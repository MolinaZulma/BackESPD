using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.JarFormatForms.Commands.CreateJarFormatForm
{
    public class CreateJarFormatFormCommand : IRequest<GenericResponse<JarFormatFormDto>>
    {
        public int JarConcentration { get; set; }
        public string JarOptime { get; set; }
        public int PhJar { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class CreateJarFormatFormCommandHandler : IRequestHandler<CreateJarFormatFormCommand, GenericResponse<JarFormatFormDto>>
    {
        private readonly IRepositoryAsync<JarFormatForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateJarFormatFormCommandHandler(IRepositoryAsync<JarFormatForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<JarFormatFormDto>> Handle(CreateJarFormatFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                JarFormatForm newJarFormatForm = _mapper.Map<CreateJarFormatFormCommand, JarFormatForm>(request);
                var jarFormatForm = await _repositoryAsync.CreateAsync(newJarFormatForm);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<JarFormatFormDto>(_mapper.Map<JarFormatFormDto>(jarFormatForm));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
