using BackESPD.Application.Features.Users.Commands.DeleteUser;
using BackESPD.Application.Features.Users.Querys.GetAllUser;
using BackESPD.Application.Features.Users.Querys.GetByIdUser;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUserQuery()));
        }

        [HttpGet("NationalIdentificationNumber")]
        public async Task<IActionResult> Get(string NationalIdentificationNumber)
        {
            return Ok(await Mediator.Send(new GetByNationalIdentificationNumberUserCommand { NationalIdentificationNumber = NationalIdentificationNumber }));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string NationalIdentificationNumber)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { NationalIdentificationNumber = NationalIdentificationNumber }));
        }
    }
}
