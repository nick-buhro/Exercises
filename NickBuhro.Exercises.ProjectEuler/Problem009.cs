using System;
using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// Special Pythagorean triplet
    /// 
    /// A Pythagorean triplet is a set of three natural numbers, a &lt; b &lt; c, for which,
    /// 
    /// a**2 + b**2 = c**2
    /// 
    /// For example, 3**2 + 4**2 = 9 + 16 = 25 = 5**2.
    /// 
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    ///
    /// <seealso href="https://projecteuler.net/problem=9"/>
    /// </summary>
    public sealed class Problem009
    {
        private const string Answer = @"31875000";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        [Fact]
        public void WellKnownTest()
        {
            // 3*3 + 4*4 = 5*5
            var actual = GetAnswer(12); // 12 = 3 + 4 + 5
            Assert.Equal("60", actual); // 60 = 3 * 4 * 5
        }

        public static string GetAnswer(int s = 1000)
        {
            // a + b + c = s
            // a ≤ b < c < a+b
            
            var aHiLimit = s/3;
            for (var a = 1; a <= aHiLimit; a++)
            {
                // c  <  a + b
                // b  >  c - a
                // b  >  (s - b - a) - a
                // 2b >  s - 2a
                // b  >  s/2 - a 
                var bLoLimit = (s >> 1) - a;

                // b  <  c
                // b  <  s - b - a
                // 2b <  s - a
                // b  <  (s - a)/2
                var bHiLimit = (s - a) >> 1;

                for (var b = bLoLimit; b <= bHiLimit; b++)
                {
                    var c = s - (a + b);
                    if ((a*a + b*b) == (c*c))
                    {
                        return (a*b*c).ToString(CultureInfo.InvariantCulture);
                    }
                }
            }

            throw new AnswerNotFoundException();
        }
    }
}
