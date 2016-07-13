using System;
using Xunit;

namespace NickBuhro.Exercises.ProjectEuler
{
    /// <summary>
    /// Multiples of 3 and 5 
    /// 
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
    /// The sum of these multiples is 23.
    /// 
    /// Find the sum of all the multiples of 3 or 5 below 1000. 
    /// 
    /// <seealso href="https://projecteuler.net/problem=1"/>
    /// </summary>
    public sealed class Problem001
    {
        [Theory]
        [InlineData(10, 23)]
        [InlineData(1000, 233168)]
        public void Test(int below, int expectedAnswer)
        {
            var actual = GetFastAnswer(below);
            Assert.Equal(expectedAnswer, actual);
        }
        

        public static int GetAnswer(int below = 1000)
        {
            var result = 0;
            for (var i = 3; i < below; i++)
            {
                if (((i % 3) == 0) || ((i % 5) == 0))
                {
                    result += i;
                }
            }
            return result;
        }


        public static int GetFastAnswer(int below = 1000)
        {
            var getSum = new Func<int, int>(multiplier =>
            {
                var count = (below - 1) / multiplier;
                return multiplier * count * (count + 1) / 2;
            });

            return getSum(3) + getSum(5) - getSum(15);
        }
    }
}
