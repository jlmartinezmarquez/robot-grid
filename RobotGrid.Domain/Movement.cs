using RobotGrid.Domain.Models;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace RobotGrid.Domain
{
    public class Movement : IMovement
    {
        public PositionVo Face(PositionVo initialPosition, char newOrientation)
        {
            return new PositionVo(initialPosition.X, initialPosition.Y, newOrientation);    
        }

        public PositionVo MoveUpFront(PositionVo initialPosition)
        {
            switch (initialPosition.Facing) 
            {
                case 'E':
                    return new PositionVo(initialPosition.X + 1, initialPosition.Y, 'E');
                case 'S':
                    return new PositionVo(initialPosition.X, initialPosition.Y - 1, 'S');
                case 'W':
                    return new PositionVo(initialPosition.X - 1, initialPosition.Y, 'W');
                case 'N':
                    return new PositionVo(initialPosition.X, initialPosition.Y + 1, 'N');
                default:
                    throw new NotImplementedException();    // TODO: log the error and throw a controlled exception
            }
        }

        public bool CheckWhetherOutOfTheGrid(GridDimensionsVo gridDimensions, PositionVo position)
        {
            var isOut = position.X > gridDimensions.X ||
                position.Y > gridDimensions.Y ||
                position.X < 0 ||
                position.Y < 0;
            
            return isOut;
        }
    }
}
