using RobotGrid.Domain.Models;

namespace RobotGrid.Domain
{
    public interface IMovement
    {
        PositionVo Face(PositionVo initialPosition, char whereTo);

        PositionVo MoveUpFront(PositionVo initialPosition);

        bool CheckWhetherOutOfTheGrid(GridDimensionsVo gridDimensions, PositionVo position);
    }
}