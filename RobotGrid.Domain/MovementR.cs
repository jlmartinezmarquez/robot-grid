using RobotGrid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotGrid.Domain
{
    public class MovementR : IMovement
    {
        public PositionVo Move(PositionVo initialPosition)
        {
            var orientations = new Dictionary<char, char>
            {
                { 'E', 'S' },
                { 'W', 'N' },
                { 'S', 'W' },
                { 'N', 'E' },
            };

            var newOrientation = orientations[initialPosition.Facing];

            return new PositionVo(initialPosition.X, initialPosition.Y, newOrientation);
        }
    }
}
