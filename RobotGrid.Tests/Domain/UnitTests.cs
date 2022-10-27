using FluentAssertions;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using Xunit;

namespace RobotGrid.Tests.Domain
{
    public class UnitTests
    {
        private readonly IMovement sut;
        
        public UnitTests()
        {
            sut = new Movement();
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
            var gridDimensions = new GridDimensionsVo(gridX, gridY);
            var initialPosition = new InitialPositionVo(robotX, robotY, robotFacing);

            var movementInstructions = new MovementInstructionVo(gridDimensions, initialPosition, movementSequence);

            var actual = sut.CalculateFinalPosition(movementInstructions);

            actual.Should().BeEquivalentTo(finalOutput);
        }
    }
}
