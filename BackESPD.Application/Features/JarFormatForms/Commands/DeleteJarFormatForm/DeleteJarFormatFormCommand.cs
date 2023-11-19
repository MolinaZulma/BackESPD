using BackESPD.Application.DTOs.JarFormatForm;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.JarFormatForms.Commands.DeleteJarFormatForm
{
    public class DeleteJarFormatFormCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteJarFormatFormCommandHandler : IRequestHandler<DeleteJarFormatFormCommand, GenericResponse<bool>> 
    {
        private readonly IRepositoryAsync<JarFormatForm> _repositoryAsync;

        public DeleteJarFormatFormCommandHandler(IRepositoryAsync<JarFormatForm> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteJarFormatFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jarFormatForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (jarFormatForm == null)
                    throw new KeyNotFoundException($"JarFormatForm con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(jarFormatForm);
                await _repositoryAsync.SaveChangesAsync();

                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
