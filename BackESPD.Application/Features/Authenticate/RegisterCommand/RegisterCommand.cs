using BackESPD.Application.DTOs.Users.Account;
using BackESPD.Application.Interfaces;
using BackESPD.Application.Wrappers;
using MediatR;

namespace BackESPD.Application.Features.Authenticate.RegisterCommand
{
    public class RegisterCommand : IRequest<GenericResponse<string>>
    {
        public string NationalIdentificationNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string NameRole { get; set; }
        public string Origin { get; set; }
    }

    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, GenericResponse<string>>
    {
        private readonly IAccountService _accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<GenericResponse<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.RegisterAsync(new RegisterRequestDto
            {
                NationalIdentificationNumber = request.NationalIdentificationNumber,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                NameRole = request.NameRole

            }, request.Origin);
        }
    }
}
