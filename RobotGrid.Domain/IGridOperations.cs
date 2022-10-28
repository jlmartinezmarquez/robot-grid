using RobotGrid.Domain.Models;

namespace RobotGrid.Domain
{
    public interface IGridOperations
    {
        bool CheckWhetherOutOfTheGrid(GridDimensionsVo gridDimensions, PositionVo position);
    }
}