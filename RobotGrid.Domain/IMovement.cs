using RobotGrid.Domain.Models;

namespace RobotGrid.Domain
{
    public interface IMovement
    {
        string CalculateFinalPosition(MovementInstructionVo movementInstruction);
    }
}