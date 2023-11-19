using BackESPD.Application.Features.JarFormatForms.Commands.CreateJarFormatForm;
using BackESPD.Application.Features.JarFormatForms.Commands.DeleteJarFormatForm;
using BackESPD.Application.Features.JarFormatForms.Commands.UpdateJarFormatForm;
using BackESPD.Application.Features.JarFormatForms.Queries.GetAllJarFormatForm;
using BackESPD.Application.Features.JarFormatForms.Queries.GetByIdJarFormatForm;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class JarFormatFormController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllJarFormatFormQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdJarFormatFormQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateJarFormatFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateJarFormatFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteJarFormatFormCommand { Id = id }));
        }
    }
}
