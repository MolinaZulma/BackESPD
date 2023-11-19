using BackESPD.Application.Features.DamageReports.Commands.CreateDamageReport;
using BackESPD.Application.Features.DamageReports.Commands.DeleteteDamageReport;
using BackESPD.Application.Features.DamageReports.Commands.UpdateDamageReport;
using BackESPD.Application.Features.DamageReports.Querys.GetAllDamageReport;
using BackESPD.Application.Features.DamageReports.Querys.GetByIdDamageReport;
using BackESPD.Application.Features.JarFormatForms.Commands.CreateJarFormatForm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class JarFormatFormController : BaseApiController
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await Mediator.Send(new GetAllDamageReportQuery()));
        //}

        //[HttpGet("id")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok(await Mediator.Send(new GetByIdDamageReportQuery { Id = id }));
        //}

        [HttpPost]
        public async Task<IActionResult> Post(CreateJarFormatFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        //[HttpPut]
        //public async Task<IActionResult> Put(UpdateDamageReportCommand entity)
        //{
        //    return Ok(await Mediator.Send(entity));
        //}


        //[HttpDelete("id")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteteDamageReportCommand { Id = id }));
        //}
    }
}
