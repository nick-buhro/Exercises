using Xunit;

namespace LeetCode.Problem327
{
    public sealed class Tests
    {
        [Theory]
        [InlineData(new[] { -2, 5, -1 }, -2, 2, 3)]
        [InlineData(new[] { -1, 1 }, 0, 0, 1)]
        [InlineData(new[] { 2147483647, -2147483648, -1, 0 }, -1, 0, 4)]
        [InlineData(new[] { 0, -3, -3, 1, 1, 2 }, 3, 5, 2)]
        [InlineData(new[] { -2147483647, 0, -2147483647, 2147483647 }, -564, 3864, 3)]
        public void Test(int[] nums, int lower, int upper, int expectedResult)
        {
            var p = new SolutionV3();
            var actualResult = p.CountRangeSum(nums, lower, upper);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
