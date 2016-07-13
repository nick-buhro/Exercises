using System.Globalization;
using Xunit;

namespace NickBuhro.Exercises.ProjectEuler
{
    /// <summary>
    /// Multiples of 3 and 5 
    /// 
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
    /// The sum of these multiples is 23.
    /// 
    /// Find the sum of all the multiples of 3 or 5 below 1000. 
    /// 
    /// <seealso cref="https://projecteuler.net/problem=1"/>
    /// </summary>
    public sealed class Problem001
    {
        private const int Answer = 233168;

        [Fact]
        public void WellKnownTest()
        {
            Assert.Equal(23, GetAnswer(10));
        }

        [Fact]
        public void FinalTest()
        {
            Assert.Equal(Answer, GetAnswer(1000));
        }
        

        public int GetAnswer(int below)
        {
            var result = 0;
            for (var i = 3; i < below; i++)
            {
                if (((i % 3) == 0) || ((i % 5) == 0))
                {
                    result += i;
                }
            }
            return result;
        }
    }
}
