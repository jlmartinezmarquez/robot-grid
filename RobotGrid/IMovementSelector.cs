using RobotGrid.Domain;

namespace RobotGrid.Api
{
    public interface IMovementSelector
    {
        IMovement GetMovement(char instruction);
    }
}