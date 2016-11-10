namespace LeetCode.Problem327
{
    /// <summary>
    /// Simple solution with O(n^2) complexity.
    /// </summary>
    public class SolutionV1
    {
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            var result = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var sum = 0;
                for (var j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    if ((lower <= sum) && (sum <= upper))
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
