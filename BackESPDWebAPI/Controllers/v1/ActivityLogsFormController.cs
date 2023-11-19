using BackESPD.Application.Features.ActivityLogsForms.Commands.CreateActivityLogsForm;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ActivityLogsFormController : BaseApiController
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Ok(await Mediator.Send(new GetAllDamageReportQuery()));
        //}

        [HttpPost]
        public async Task<IActionResult> Post(CreateActivityLogsFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

    }
}
