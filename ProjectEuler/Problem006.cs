using System;
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
        [Theory]
        [InlineData(2640, 10)]
        [InlineData(25164150, 100)]
        public static void Test(int expectedResult, int limit)
        {
            var getSum = new Func<int, int>(n => (n + 1)*n/2);
            var getSumOfSquares = new Func<int, int>(n => (2*n + 1)*(n + 1)*n/6);
            
            var sum = getSum(limit);
            var result = sum*sum - getSumOfSquares(limit);

            Assert.Equal(expectedResult, result);            
        }
    }
}
