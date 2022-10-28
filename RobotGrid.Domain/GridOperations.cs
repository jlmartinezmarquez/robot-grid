using Microsoft.Extensions.Configuration;
using RobotGrid.Domain.Models;
using System;
using System.Collections.Generic;

namespace RobotGrid.Domain
{
    public class GridOperations : IGridOperations
    {
        private readonly IConfiguration configuration;

        public GridOperations(IConfiguration configuration)
        {
            this.configuration = configuration;
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
