using System;
using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// Summation of primes
    /// 
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// 
    /// Find the sum of all the primes below two million.
    ///
    /// <seealso href="https://projecteuler.net/problem=10"/>
    /// </summary>
    public sealed class Problem010
    {            
        private const string Answer = @"142913828922";

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
            Assert.Equal("17", actual);
        }

        public static string GetAnswer(int limit = 2000000)
        {
            // Solution is based on Sieve of Eratosthenes alghoritm (https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
            // Optimization: array will be allocated only for the odd numbers.

            // Sieve definition. Meaning:
            // - number = index * 2 + 1
            // - value is false for primes and true for non-primes
            var s = new bool[limit >> 1];
            var getNumberByIndex = new Func<int, int>(i => (i << 1) | 1); // i * 2 + 1
            
            // Fill sieve
            var iLimit = Math.Sqrt(s.Length) + 1;
            for (var i = 1; i < iLimit; i++)
            {
                if (s[i]) continue;
                var number = getNumberByIndex(i);
                var doubleNumber = number << 1;
                for (var k = number + doubleNumber; k < limit; k += doubleNumber)
                {
                    s[k >> 1] = true;
                }
            }

            // Calculate result
            var sum = 2L;
            for (var i = 1; i < s.Length; i++)
            {
                if (!s[i])
                {
                    sum += getNumberByIndex(i);
                }
            }

            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}
