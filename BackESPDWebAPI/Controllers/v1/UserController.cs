﻿using BackESPD.Application.Features.SampleForms.Commands.UpdateSampleForm;
using BackESPD.Application.Features.Users.Commands;
using BackESPD.Application.Features.Users.Commands.DeleteUser;
using BackESPD.Application.Features.Users.Commands.RecoverPassword;
using BackESPD.Application.Features.Users.Commands.UpdateUser;
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

        [HttpPut("reset-password")]
        public async Task<IActionResult> Put(UpdateUsers entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string NationalIdentificationNumber)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { NationalIdentificationNumber = NationalIdentificationNumber }));
        }





        //[HttpPost("sendEmailrecoverPassword")]

        //public async Task<IActionResult> SendEmailrecoverPassword(RecoverPasswordCommand entity)
        //{
        //    return Ok(await Mediator.Send(entity));
        //}



    }
}
