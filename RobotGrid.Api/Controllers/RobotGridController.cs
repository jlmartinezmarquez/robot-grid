using Microsoft.AspNetCore.Mvc;
using RobotGrid.Api.Mappers;
using RobotGrid.Api.Services;

namespace RobotGrid.Api.Controllers
{
    [ApiController]
    [Route("api/v1/robotgrid")]     // TODO: Take version from major project version
    public class RobotGridController : ControllerBase
    {
        private readonly IRobotGridService service;
        private readonly IRestMapper mapper;

        public RobotGridController(IRobotGridService service, IRestMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet("next-position")]
        public ActionResult<string> GetNextPosition(
            [FromQuery(Name = "gx")] string gridX,
            [FromQuery(Name = "gy")] string gridY,
            [FromQuery(Name = "ix")] string initX,
            [FromQuery(Name = "iy")] string initY,
            [FromQuery(Name = "f")] string initFacing,
            [FromQuery(Name = "ins")] string instructions)
        {
            // TODO: Perform some format and value range validations

            var movementInstructions = mapper.FromUrlToMovementInstructions(gridX, gridY, initX, initY, initFacing, instructions);

            var finalPosition = service.CalculateFinalPosition(movementInstructions);

            return Ok(finalPosition);
        }
    }
}
