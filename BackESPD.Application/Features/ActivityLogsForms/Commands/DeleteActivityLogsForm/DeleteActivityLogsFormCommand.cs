using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.ActivityLogsForms.Commands.DeleteActivityLogsForm
{
    public class DeleteActivityLogsFormCommand : IRequest<GenericResponse<bool>>
    {
        public int Id { get; set; }
    }

    internal class DeleteActivityLogsFormCommandHandler : IRequestHandler<DeleteActivityLogsFormCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<ActivityLogsForm> _repositoryAsync;

        public DeleteActivityLogsFormCommandHandler(IRepositoryAsync<ActivityLogsForm> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteActivityLogsFormCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var activityLogsForm = await _repositoryAsync.GetAsync(tp => tp.Id == request.Id);
                if (activityLogsForm == null)
                    throw new KeyNotFoundException($"ActivityLogsForm con el id: {request.Id} no existe");

                await _repositoryAsync.DeleteAsync(activityLogsForm);
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
