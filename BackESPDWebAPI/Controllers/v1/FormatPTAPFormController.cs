using BackESPD.Application.Features.FormatPTAPForms.Commands.CreateFormatPTAPForm;
using BackESPD.Application.Features.FormatPTAPForms.Commands.DeleteFormatPTAPForm;
using BackESPD.Application.Features.FormatPTAPForms.Commands.UpdateFormatPTAPForm;
using BackESPD.Application.Features.FormatPTAPForms.Queries.GetAllFormatPTAPForm;
using BackESPD.Application.Features.FormatPTAPForms.Queries.GetByIdFormatPTAPForm;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FormatPTAPFormController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllFormatPTAPFormQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdFormatPTAPFormQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFormatPTAPFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateFormatPTAPFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFormatPTAPFormCommand { Id = id }));
        }
    }
}
