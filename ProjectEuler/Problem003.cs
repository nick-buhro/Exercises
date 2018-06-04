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
        [Theory]
        [InlineData(29, 13195L)]
        [InlineData(6857, 600851475143L)]
        public static void Test(int expectedResult, long number)
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

            Assert.Equal(expectedResult, result);
        }
    }
}
