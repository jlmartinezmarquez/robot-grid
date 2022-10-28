using FluentAssertions;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using Xunit;

namespace RobotGrid.Tests.Domain
{
    public class MovementLTests
    {
        private readonly IMovement sut;

        public MovementLTests()
        {
            sut = new MovementL();
        }

        [Theory]
        [InlineData(1, 2, 'E', 1, 2, 'N')]
        public void Should_Face(int initX, int initY, char initFacing, int finalX, int finalY, char finalFacing)
        {
            var initialPosition = new PositionVo(initX, initY, initFacing);
            var expected = new PositionVo(finalX, finalY, finalFacing);

            var actual = sut.Move(initialPosition);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
