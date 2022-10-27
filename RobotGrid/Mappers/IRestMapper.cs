using RobotGrid.Api.Models;

namespace RobotGrid.Api.Mappers
{
    public interface IRestMapper
    {
        MovementInstructions FromUrlToMovementInstructions(
            string gridX,
            string gridY,
            string initX,
            string initY,
            string initFacing,
            string instructions);
    }
}