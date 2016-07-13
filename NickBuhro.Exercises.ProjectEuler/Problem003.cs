using Xunit;

namespace NickBuhro.Exercises.ProjectEuler
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
        [InlineData(13195L, 29L)]
        [InlineData(600851475143L, 6857L)]
        public void Test(long number, long largestPrimeFactor)
        {
            var actual = GetAnswer(number);
            Assert.Equal(largestPrimeFactor, actual);
        }

        public static long GetAnswer(long number = 600851475143L)
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
            return result;
        }
    }
}
