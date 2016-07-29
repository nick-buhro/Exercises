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

        public static string GetAnswer()
        {
            // a + b + c = 1000
            // a ≤ b < c < a+b

            // a < 1000/3
            for (var a = 1; a <= 333; a++)
            {
                // c  <  a + b
                // b  >  c - a
                // b  >  (1000 - b - a) - a
                // 2b >  1000 - 2a
                // b  >  500 - a 
                var bLoLimit = 500 - a;

                // b  <  c
                // b  <  1000 - b - a
                // 2b <  1000 - a
                // b  <  500 - a/2
                var bHiLimit = 500 - (a >> 1);

                for (var b = bLoLimit; b <= bHiLimit; b++)
                {
                    var c = 1000 - (a + b);
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
