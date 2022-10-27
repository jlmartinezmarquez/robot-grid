using FluentAssertions;
using System;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Xunit;

namespace RobotGrid.Tests.Api
{
    public class FunctionalTests : IClassFixture<ClassFixture>
    {
        private readonly ClassFixture fixture;

        public FunctionalTests(ClassFixture fixture)
        {
            this.fixture = fixture; //We have access here to any public property that needs to be initialised at the beginning of ALL tests
        }

        [Fact]
        public async Task Should()
        {
            var response = await fixture.Client.GetAsync($"/api/v1/robotgrid/aaa");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(5, 3, 1, 1, 'E', "RFRFRFRF", "1 1 E")]
        [InlineData(5, 3, 3, 2, 'N', "FRRFLLFFRRFLL", "3 3 N LOST")]
        [InlineData(5, 3, 0, 3, 'W', "LLFFFRFLFL", "4 2 N")]
        public async Task Should_CalculateFinalPosition(
            int gridX,
            int gridY,
            int robotX,
            int robotY,
            char robotFacing,
            string movementSequence,
            string finalOutput)
        {
            var response = await fixture.Client.GetAsync($"/api/v1/robotgrid/next-position?gx={gridX}&gy={gridY}ix={robotX}iy={robotY}f={robotFacing}ins={movementSequence}");

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }
    }
}
