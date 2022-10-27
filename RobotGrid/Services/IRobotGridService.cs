using RobotGrid.Api.Models;

namespace RobotGrid.Api.Services
{
    public interface IRobotGridService
    {
        string CalculateFinalPosition(MovementInstructions movementInstruction);
    }
}