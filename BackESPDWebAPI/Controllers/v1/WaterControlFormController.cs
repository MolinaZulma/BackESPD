using BackESPD.Application.Features.WaterControlForms.Commands.CreateWaterControlForm;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WaterControlFormController : BaseApiController
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
        public async Task<IActionResult> Post(CreateWaterControlFormCommand entity)
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
