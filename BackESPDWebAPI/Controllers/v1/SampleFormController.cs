using BackESPD.Application.Features.SampleForms.Commands.CreateSampleForm;
using BackESPD.Application.Features.SampleForms.Commands.DeleteSampleForm;
using BackESPD.Application.Features.SampleForms.Commands.UpdateSampleForm;
using BackESPD.Application.Features.SampleForms.Queries.GetAllSampleForm;
using BackESPD.Application.Features.SampleForms.Queries.GetByIdSampleForm;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class SampleFormController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllSampleFormQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdSampleFormQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSampleFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateSampleFormCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteSampleFormCommand { Id = id }));
        }
    }
    }
