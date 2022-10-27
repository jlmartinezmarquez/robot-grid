using System;
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
        public void Test1()
        {

        }
    }
}
