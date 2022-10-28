using RobotGrid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGrid.Domain
{
    public class MovementL : IMovement
    {
        public PositionVo Move(PositionVo initialPosition)
        {
            var orientations = new Dictionary<char, char>
            {
                { 'E', 'N' },
                { 'W', 'S' },
                { 'S', 'E' },
                { 'N', 'W' },
            };

            var newOrientation = orientations[initialPosition.Facing];

            return new PositionVo(initialPosition.X, initialPosition.Y, newOrientation);
        }
    }
}
