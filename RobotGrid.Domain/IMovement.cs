using RobotGrid.Domain.Models;

namespace RobotGrid.Domain
{
    public interface IMovement
    {
        PositionVo Move(PositionVo initialPosition);
    }
}