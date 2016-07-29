using System;
using System.Globalization;
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
        private const string Answer = @"233168";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        [Fact]
        public void WellKnownTest()
        {
            var expected = "23";
            var actual = GetAnswer(10);
            Assert.Equal(expected, actual);
        }
        
        private static string GetAnswer(int below = 1000)
        {
            var getSum = new Func<int, int>(multiplier =>
            {
                var count = (below - 1) / multiplier;
                return multiplier * count * (count + 1) / 2;
            });

            var result = getSum(3) + getSum(5) - getSum(15);
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
