using System;
using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// 10001st prime
    /// 
    /// By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    /// 
    /// What is the 10 001st prime number?
    ///
    /// <seealso href="https://projecteuler.net/problem=7"/>
    /// </summary>
    public sealed class Problem007
    {            
        private const string Answer = @"104743";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        [Fact]
        public void WellKnownTest()
        {
            var actual = GetAnswer(6);
            Assert.Equal("13", actual);
        }

        public static string GetAnswer(int index = 10001)
        {
            // Solution is based on Sieve of Eratosthenes alghoritm (https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
            // Sieve size can be calulated by the prime number theorem (https://en.wikipedia.org/wiki/Prime_number_theorem).
            // Optimization: array will be allocated only for the odd numbers.

            var estimatePrimeValue = index * Math.Log10(index);
            estimatePrimeValue = estimatePrimeValue*1.1 + 100000;    // Add a little bit for confedence

            // Sieve definition. Meaning:
            // - number = index * 2 + 1
            // - value is false for primes and true for non-primes
            var s = new bool[Convert.ToInt32(estimatePrimeValue/2)];
            var getNumberByIndex = new Func<int, int>(i => (i << 1) | 1); // i * 2 + 1

            var numberLimit = s.Length << 1;    // *2
            var iLimit = Math.Sqrt(s.Length) + 1;
            for (var i = 1; i < iLimit; i++)
            {
                if (s[i]) continue;
                var number = getNumberByIndex(i); 
                var doubleNumber = number << 1;
                for (var k = number + doubleNumber; k < numberLimit; k += doubleNumber)
                {
                    s[k >> 1] = true;
                }
            }

            // Find prime
            var count = 1;
            for (var i = 1; i < s.Length; i++)
            {
                if (s[i]) continue;

                count++;
                if (count == index)
                {
                    return getNumberByIndex(i).ToString(CultureInfo.InvariantCulture);
                }
            }

            // Sieve is too small...
            throw new AnswerNotFoundException();
        }
    }
}
