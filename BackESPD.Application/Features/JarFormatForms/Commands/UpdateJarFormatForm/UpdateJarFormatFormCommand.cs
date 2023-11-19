using AutoMapper;
using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.JarFormatForms.Commands.UpdateJarFormatForm
{
    public class UpdateJarFormatFormCommand : IRequest<GenericResponse<JarFormatFormDto>>
    {
        public int Id { get; set; }
        public int JarConcentration { get; set; }
        public string JarOptime { get; set; }
        public int PhJar { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public int IdPlant { get; set; }
    }

    internal class UpdateJarFormatFormCommandHandler : IRequestHandler<UpdateJarFormatFormCommand, GenericResponse<JarFormatFormDto>>
    {
        private readonly IRepositoryAsync<JarFormatForm> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateJarFormatFormCommandHandler(IRepositoryAsync<JarFormatForm> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<GenericResponse<JarFormatFormDto>> Handle(UpdateJarFormatFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jarFormatForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (jarFormatForm == null)
                    throw new KeyNotFoundException($"JarFormatForm con el id: {request.Id} no existe");

                jarFormatForm.JarConcentration = request.JarConcentration;
                jarFormatForm.JarOptime = request.JarOptime;
                jarFormatForm.PhJar = request.PhJar;
                jarFormatForm.NationalIdentificationNumber = request.NationalIdentificationNumber;
                jarFormatForm.IdPlant = request.IdPlant;

                await _repositoryAsync.UpdateAsync(jarFormatForm);
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
