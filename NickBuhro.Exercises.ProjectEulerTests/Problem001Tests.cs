using NickBuhro.Exercises.ProjectEuler;
using Xunit;

namespace NickBuhro.Exercises.ProjectEulerTests
{
    public sealed class Problem001Tests
    {
        [Fact]
        public void WellKnownTest()
        {
            var problem = new Problem001();
            var actual = problem.GetAnswer(10);
            Assert.Equal("23", actual);
        }

        [Fact]
        public void FinalTest()
        {
            var problem = new Problem001();
            var actual = problem.GetAnswer(1000);
            Assert.Equal("233168", actual);
        }
    }
}
