using Xunit;

namespace LeetCode.Problem327
{
    public sealed class Tests
    {
        private readonly SolutionV1 _problem = new SolutionV1();

        [Fact]
        public void ExampleTest()
        {
            var nums = new [] {-2, 5, -1};
            const int lower = -2;
            const int upper = 2;

            const int expectedResult = 3;
            
            var actualResult = _problem.CountRangeSum(nums, lower, upper);
            Assert.Equal(expectedResult, actualResult);
        }

    }
}
