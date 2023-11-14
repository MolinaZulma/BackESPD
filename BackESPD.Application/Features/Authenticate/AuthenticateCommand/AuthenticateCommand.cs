using BackESPD.Application.DTOs.Users.Account;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using MediatR;

namespace BackESPD.Application.Features.Authenticate.AuthenticateCommand
{
    public class AuthenticateCommand : IRequest<GenericResponse<AuthenticationResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }

    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, GenericResponse<AuthenticationResponseDto>>
    {
        private readonly IAccountService _accountService;

        public AuthenticateCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<GenericResponse<AuthenticationResponseDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.AuthenticateAsync(new AuthenticationRequestDto
            {
                Email = request.Email,
                Password = request.Password,
            }, request.IpAddress);
        }
    }
}
