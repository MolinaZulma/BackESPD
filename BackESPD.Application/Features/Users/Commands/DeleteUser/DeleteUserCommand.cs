using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using BackESPD.Domain.Entities;
using MediatR;

namespace BackESPD.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<GenericResponse<bool>>
    {
        public string NationalIdentificationNumber { get; set; }
    }

    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, GenericResponse<bool>>
    {
        private readonly IRepositoryAsync<User> _repositoryAsync;

        public DeleteUserCommandHandler(IRepositoryAsync<User> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<GenericResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _repositoryAsync.GetAsync(tp => tp.NationalIdentificationNumber == request.NationalIdentificationNumber);
                if (user == null)
                    throw new KeyNotFoundException($"User con el NationalIdentificationNumber: {request.NationalIdentificationNumber} no existe");

                await _repositoryAsync.DeleteAsync(user);
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
