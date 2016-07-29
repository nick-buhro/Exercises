using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// Largest prime factor
    /// 
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// 
    /// What is the largest prime factor of the number 600851475143 ?
    /// 
    /// <seealso href="https://projecteuler.net/problem=3"/>
    /// </summary>
    public sealed class Problem003
    {
        private const string Answer = @"6857";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        [Fact]
        public void WellKnownTest()
        {
            var expected = "29";
            var actual = GetAnswer(13195L);
            Assert.Equal(expected, actual);
        }

        public static string GetAnswer(long number = 600851475143L)
        {
            var result = 1;
            for (var i = 2; i <= number; i++)
            {
                while ((i <= number) && ((number % i) == 0))
                {
                    number = number/i;
                    result = i;
                }
            }
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
