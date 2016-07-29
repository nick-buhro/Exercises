using System;
using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// Bitwise-OR operations on random integers
    /// 
    /// Let y0, y1, y2,... be a sequence of random unsigned 32 bit integers
    /// (i.e. 0 ≤ yi ≤ (2**32 - 1), every value equally likely).
    /// 
    /// For the sequence xi the following recursion is given:
    /// 
    /// x0 = 0 and xi = xi-1 | yi-1, for i > 0. ( | is the bitwise-OR operator)
    /// 
    /// It can be seen that eventually there will be an index N such that xi = 2**32 -1 
    /// (a bit-pattern of all ones) for all i ≥ N.
    /// 
    /// Find the expected value of N. 
    /// Give your answer rounded to 10 digits after the decimal point.
    ///
    /// <seealso href="https://projecteuler.net/problem=323"/>
    /// </summary>
    public sealed class Problem323
    {
        private const string Answer = "6.3551758451";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        public static string GetAnswer()
        {
            // We can calculate expected value by the formula:
            //
            //     e = 1*p1 + 2*p2 + 3*p3 + ...
            //
            // where pi - probability to rich the finish (xi = 2**32 -1) by EXACT i numbers;
            //       i  - sequence index.
            // 
            // Let's say that we should stop when a summand i*pi will be less than 1E-11 (treshold).
            //
            // ### Probability calculation
            //
            // For i pieces of 1-bit numbers probability of having true OR-result is:
            // 
            //     1 - 0.5**i
            //
            // So for i 32-bit numbers it will be:
            //
            //     pa = (1 - 0.5**i) ** 32;
            //
            // What is the probability of reaching target OR-result only with EXACT i-th number? It will be:
            //
            //     p = pa(i) - pa(i-1)
            //
            // Let's calculate!            

            var treshold = Math.Pow(0.1, 11);

            double e = 0;
            double paPrev = 0; // pa(i-1)
            for (var i = 1; true; i++)
            {
                var pa = Math.Pow(1 - Math.Pow(0.5, i), 32); // pa(i)
                var p = pa - paPrev;
                var summand = i * p;

                if (summand < treshold)
                    break;

                e = e + summand;
                paPrev = pa;
            }
            return e.ToString("F10", CultureInfo.InvariantCulture);
        }
    }
}
