using Xunit;

namespace LeetCode.Problem327
{
    public sealed class Tests
    {


        private readonly SolutionV2 _problem = new SolutionV2();

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

        [Fact]
        public void SubmissionFail01()
        {
            var nums = new[] { -1, 1 };
            const int lower = 0;
            const int upper = 0;

            const int expectedResult = 1;

            var actualResult = _problem.CountRangeSum(nums, lower, upper);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SubmissionFail02()
        {
            var nums = new[] {2147483647, -2147483648, -1, 0};
            const int lower = -1;
            const int upper = 0;

            const int expectedResult = 4;

            var actualResult = _problem.CountRangeSum(nums, lower, upper);
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void SubmissionFail03()
        {
            var nums = new[] {0, -3, -3, 1, 1, 2};
            const int lower = 3;
            const int upper = 5;

            const int expectedResult = 2;

            var actualResult = _problem.CountRangeSum(nums, lower, upper);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
