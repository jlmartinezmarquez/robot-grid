using FluentAssertions;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using Xunit;

namespace RobotGrid.Tests.Domain
{
    public class MovementRTests
    {
        private readonly IMovement sut;

        public MovementRTests()
        {
            sut = new MovementR();
        }

        [Theory]
        [InlineData(5, 5, 'S', 5, 5, 'W')]
        public void Should_Face(int initX, int initY, char initFacing, int finalX, int finalY, char finalFacing)
        {
            var initialPosition = new PositionVo(initX, initY, initFacing);
            var expected = new PositionVo(finalX, finalY, finalFacing);

            var actual = sut.Move(initialPosition);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
