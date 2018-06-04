using System;

namespace LeetCode.Problem135
{
    public class SolutionV2
    {
        public int Candy(int[] ratings)
        {
            if (ratings.Length <= 1)
                return ratings.Length;

            var num = new int[ratings.Length];
            for (var i = 0; i < num.Length; i++)
                num[i] = 1;

            for (var i = 1; i < num.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                    num[i] = num[i - 1] + 1;
            }

            for (var i = num.Length - 1; i > 0; i--)
            {
                if (ratings[i - 1] > ratings[i])
                    num[i - 1] = Math.Max(num[i] + 1, num[i - 1]);
            }
            
            var result = 0;
            // LINQ-expression num.Sum() degrades performance
            // ReSharper disable once LoopCanBeConvertedToQuery
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < num.Length; i++)
            {
                result += num[i];
            }
            return result;
        }
    }
}
