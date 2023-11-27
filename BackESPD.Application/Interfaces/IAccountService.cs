using BackESPD.Application.DTOs.Users.Account;
using BackESPD.Application.Wrappers;
using System.Runtime.CompilerServices;

namespace BackESPD.Application.Interfaces
{
    public interface IAccountService
    {
        Task<GenericResponse<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequestDto request, string ipAddress);
        Task<GenericResponse<string>> RegisterAsync(RegisterRequestDto request, string origin);

        Task<GenericResponse<string>> ChangeRole(string userId, string roleName);
    }
}
