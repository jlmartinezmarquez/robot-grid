using RobotGrid.Domain.Models;
using System;

namespace RobotGrid.Domain
{
    public class MovementF : IMovement
    {
        public PositionVo Move(PositionVo initialPosition)
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
    }
}
