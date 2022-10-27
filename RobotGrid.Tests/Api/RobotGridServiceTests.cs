using FluentAssertions;
using RobotGrid.Api.Models;
using RobotGrid.Api.Services;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RobotGrid.Tests.Api
{
    public class RobotGridServiceTests
    {
        private readonly IRobotGridService sut;

        public RobotGridServiceTests()
        {
            sut = new RobotGridService(new Movement());
        }

        [Theory]
        [InlineData(5, 3, 1, 1, 'E', "RFRFRFRF", "1 1 E")]
        [InlineData(5, 3, 3, 2, 'N', "FRRFLLFFRRFLL", "3 3 N LOST")]
        [InlineData(5, 3, 0, 3, 'W', "LLFFFRFLFL", "4 2 N")]
        public void Should_CalculateFinalPosition(
            int gridX,
            int gridY,
            int robotX,
            int robotY,
            char robotFacing,
            string movementSequence,
            string finalOutput)
        {
            var gridDimensions = new GridDimensions { X = gridX, Y = gridY };
            var initialPosition = new Position { X = robotX, Y = robotY, Facing = robotFacing };

            var movementInstructions = new MovementInstructions
            {
                GridDimensions = gridDimensions,
                InitialPosition = initialPosition,
                Instructions = movementSequence
            };

            var actual = sut.CalculateFinalPosition(movementInstructions);

            actual.Should().BeEquivalentTo(finalOutput);
        }
    }
}
