using BackESPD.Application.Features.ActivityLogsForms.Commands.CreateActivityLogsForm;
using BackESPD.Application.Features.ActivityLogsForms.Commands.DeleteActivityLogsForm;
using BackESPD.Application.Features.ActivityLogsForms.Commands.UpdateActivityLogsForm;
using BackESPD.Application.Features.ActivityLogsForms.Queries.GetAllActivityLogsForm;
using BackESPD.Application.Features.ActivityLogsForms.Queries.GetByIdActivityLogsForm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ActivityLogsFormController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllActivityLogsFormQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdActivityLogsFormQuery { Id = id }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateActivityLogsFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateActivityLogsFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteActivityLogsFormCommand { Id = id }));
        }
    }
}
