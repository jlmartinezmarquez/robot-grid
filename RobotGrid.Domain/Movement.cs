using Microsoft.Extensions.Configuration;
using RobotGrid.Domain.Models;
using System;
using System.Collections.Generic;

namespace RobotGrid.Domain
{
    public class Movement : IMovement
    {
        private readonly IConfiguration configuration;

        public Movement(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public PositionVo Face(PositionVo initialPosition, char instruction)
        {
            var orientations = new Dictionary<string, char>
            {
                { "E L", 'N' },
                { "E R", 'S' },
                { "W L", 'S' },
                { "W R", 'N' },
                { "S L", 'E' },
                { "S R", 'W' },
                { "N L", 'W' },
                { "N R", 'E' },
            };

            var composedKey = $"{initialPosition.Facing} {instruction}";
            var newOrientation = orientations[composedKey];

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
            var maxCoordinateNumber = int.Parse(configuration.GetValue<string>("MaximumCoordinateNumber"));

            var isOut = position.X >= gridDimensions.X ||
                position.Y >= gridDimensions.Y ||
                position.X < 0 ||
                position.Y < 0 ||
                position.X > maxCoordinateNumber ||
                position.Y > maxCoordinateNumber;
            
            return isOut;
        }
    }
}
