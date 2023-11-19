using BackESPD.Application.Features.Plants.Commands.CreatePlant;
using BackESPD.Application.Features.Plants.Commands.DeletePlant;
using BackESPD.Application.Features.Plants.Commands.UpdatePlant;
using BackESPD.Application.Features.Plants.Queries.GetAllPlant;
using BackESPD.Application.Features.Plants.Queries.GetByIdPlant;
using Microsoft.AspNetCore.Mvc;

namespace BackESPDWebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PlantController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPlantQuery()));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetByIdPlantQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePlantCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePlantCommand entity)
        {
            return Ok(await Mediator.Send(entity));
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePlantCommand { Id = id }));
        }
    }
}
