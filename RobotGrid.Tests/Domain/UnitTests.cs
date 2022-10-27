using FluentAssertions;
using Microsoft.Extensions.Configuration;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace RobotGrid.Tests.Domain
{
    public class UnitTests
    {
        private readonly IMovement sut;
        
        public UnitTests()
        {
            var inMemorySettings = new Dictionary<string, string> { { "MaximumCoordinateNumber", "50"} };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            sut = new Movement(configuration);
        }

        [Theory]
        [InlineData(1, 2, 'E', 'W', 1, 2, 'W')]
        [InlineData(5, 5, 'S', 'N', 5, 5, 'N')]
        public void Should_Face(int initX, int initY, char initFacing, char newFacing, int finalX, int finalY, char finalFacing)
        {
            var initialPosition = new PositionVo(initX, initY, initFacing);
            var expected = new PositionVo(finalX, finalY, finalFacing);

            var actual = sut.Face(initialPosition, newFacing);

            actual.Should().BeEquivalentTo(expected);
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

            var actual = sut.MoveUpFront(initialPosition);

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_MoveUpFront_WrongInput()
        {
            var initialPosition = new PositionVo(2, 2, 'Z');

           Assert.Throws<NotImplementedException>(() => sut.MoveUpFront(initialPosition));
        }

        [Theory]
        [InlineData(5, 2, 1, 1, false)]
        [InlineData(5, 2, 5, 2, false)]
        [InlineData(5, 2, 6, 2, true)]
        [InlineData(5, 2, 4, 3, true)]
        [InlineData(5, 2, -4, 3, true)]
        [InlineData(5, 2, 4, -3, true)]
        public void Should_CheckWhetherOutOfTheGrid(int gridX, int gridY, int initX, int initY, bool expected)
        {
            var gridDimensions = new GridDimensionsVo(gridX, gridY);
            var initialPosition = new PositionVo(initX, initY, 'E');

            var actual = sut.CheckWhetherOutOfTheGrid(gridDimensions, initialPosition);

            actual.Should().Be(expected);
        }
    }
}
