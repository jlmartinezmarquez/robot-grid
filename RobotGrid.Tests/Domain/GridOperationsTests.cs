using FluentAssertions;
using Microsoft.Extensions.Configuration;
using RobotGrid.Domain;
using RobotGrid.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace RobotGrid.Tests.Domain
{
    public class GridOperationsTests
    {
        private readonly IGridOperations sut;

        public GridOperationsTests()
        {
            var inMemorySettings = new Dictionary<string, string> { { "MaximumCoordinateNumber", "50" } };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            sut = new GridOperations(configuration);
        }

        [Theory]
        [InlineData(5, 2, 1, 1, false)]
        [InlineData(5, 2, 5, 2, true)]
        [InlineData(5, 2, 6, 2, true)]
        [InlineData(5, 2, 4, 3, true)]
        [InlineData(5, 2, -4, 1, true)]
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
