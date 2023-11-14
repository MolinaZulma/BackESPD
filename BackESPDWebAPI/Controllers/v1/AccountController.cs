using BackESPD.Application.DTOs.Users.Account;
using BackESPD.Application.Features.Authenticate.AuthenticateCommand;
using BackESPD.Application.Features.Authenticate.RegisterCommand;
using BackESPD.Application.Features.Users.Querys.GetAllUser;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {




        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequestDto request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                Email = request.Email,
                NameRole = request.NameRole,
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
                NationalIdentificationNumber = request.NationalIdentificationNumber,
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Origin = Request.Headers["origin"]
            }));
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequestDto request)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIPAddress()
            }));
        }
        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        //Esta aqui temporalmente   
        [HttpGet]
        [Route("users/getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUserQuery()));
        }

    }
}
