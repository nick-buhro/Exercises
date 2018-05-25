using System;
using Xunit;

namespace Euler
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
        [InlineData(23, 10)]
        [InlineData(233168, 1000)]
        private static void Test(int expectedResult, int below)
        {
            var getSum = new Func<int, int>(multiplier =>
            {
                var count = (below - 1) / multiplier;
                return multiplier * count * (count + 1) / 2;
            });

            var result = getSum(3) + getSum(5) - getSum(15);            

            Assert.Equal(expectedResult, result);
        }
    }
}
