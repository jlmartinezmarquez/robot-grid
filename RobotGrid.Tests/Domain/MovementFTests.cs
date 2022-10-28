using FluentAssertions;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System;
using Xunit;

namespace RobotGrid.Tests.Domain
{
    public class MovementFTests
    {
        private readonly IMovement sut;

        public MovementFTests()
        {
            sut = new MovementF();
        }

        [Theory]
        [InlineData(0, 2, 'E', 1, 2, 'E')]
        [InlineData(1, 0, 'S', 1, -1, 'S')]
        [InlineData(0, 2, 'W', -1, 2, 'W')]
        [InlineData(0, 2, 'N', 0, 3, 'N')]
        public void Should_MoveUpFront(int initX, int initY, char initFacing, int finalX, int finalY, char finalFacing)
        {
            var initialPosition = new PositionVo(initX, initY, initFacing);
            var expected = new PositionVo(finalX, finalY, finalFacing);

            var actual = sut.Move(initialPosition);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_MoveUpFront_WrongInput()
        {
            var initialPosition = new PositionVo(2, 2, 'Z');

            Assert.Throws<NotImplementedException>(() => sut.Move(initialPosition));
        }
    }
}
