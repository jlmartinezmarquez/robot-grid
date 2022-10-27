using RobotGrid.Api.Models;

namespace RobotGrid.Api.Mappers
{
    public class RestMapper : IRestMapper
    {
        public MovementInstructions FromUrlToMovementInstructions(
            string gridX,
            string gridY,
            string initX,
            string initY,
            string initFacing,
            string instructions)
        {
            return new MovementInstructions
            {
                GridDimensions = new GridDimensions
                {
                    X = int.Parse(gridX),
                    Y = int.Parse(gridY)
                },
                Instructions = instructions,
                InitialPosition = new Position
                {
                    X = int.Parse(initX),
                    Y = int.Parse(initY),
                    Facing = initFacing[0]
                }
            };
        }
    }
}