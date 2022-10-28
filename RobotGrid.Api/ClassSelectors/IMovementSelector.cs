using RobotGrid.Domain;

namespace RobotGrid.Api.ClassSelectors
{
    public interface IMovementSelector
    {
        IMovement GetMovement(char instruction);
    }
}