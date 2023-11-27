using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using MediatR;

namespace BackESPD.Application.Features.Users.Commands.ChangeUserRole
{
    public class ChangeUserRoleCommand : IRequest<GenericResponse<bool>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }

    internal class ChangeUserRoleCommandHandler : IRequestHandler<ChangeUserRoleCommand, GenericResponse<bool>>
    {
        private readonly IAccountService _accountService;

        public ChangeUserRoleCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<GenericResponse<bool>> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
        {

            try
            {
                await _accountService.ChangeRole(request.UserId, request.RoleName);
                return new GenericResponse<bool>(true);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
