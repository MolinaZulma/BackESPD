using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.FormatPTAPForms.Commands.DeleteFormatPTAPForm
{
    public class DeleteFormatPTAPFormCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteFormatPTAPFormCommandHandler : IRequestHandler<DeleteFormatPTAPFormCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<FormatPTAPForm> _repositoryAsync;

        public DeleteFormatPTAPFormCommandHandler(IRepositoryAsync<FormatPTAPForm> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteFormatPTAPFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var formatPTAPForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (formatPTAPForm == null)
                    throw new KeyNotFoundException($"FormatPTAPForm con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(formatPTAPForm);
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
