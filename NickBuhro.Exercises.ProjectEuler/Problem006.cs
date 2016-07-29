using System;
using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// Sum square difference
    /// 
    /// The sum of the squares of the first ten natural numbers is,
    /// 
    /// 1**2 + 2**2 + ... + 10**2 = 385
    /// 
    /// The square of the sum of the first ten natural numbers is,
    /// 
    /// (1 + 2 + ... + 10)**2 = 55**2 = 3025
    /// 
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    /// 
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    ///
    /// <seealso href="https://projecteuler.net/problem=6"/>
    /// </summary>
    public sealed class Problem006
    {            
        private const string Answer = @"25164150";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        [Fact]
        public void WellKnownTest()
        {
            var actual = GetAnswer(10);
            Assert.Equal("2640", actual);
        }

        public static string GetAnswer(int limit = 100)
        {
            var getSum = new Func<int, int>(n => (n + 1)*n/2);
            var getSumOfSquares = new Func<int, int>(n => (2*n + 1)*(n + 1)*n/6);
            
            var sum = getSum(limit);
            var result = sum*sum - getSumOfSquares(limit);
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
