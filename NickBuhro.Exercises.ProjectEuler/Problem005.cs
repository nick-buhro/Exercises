using System.Globalization;
using Xunit;

namespace Euler
{
    /// <summary>
    /// Smallest multiple
    /// 
    /// 2520 is the smallest number that can be divided by each of the numbers 
    /// from 1 to 10 without any remainder.
    /// 
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    ///
    /// <seealso href="https://projecteuler.net/problem=5"/>
    /// </summary>
    public sealed class Problem005
    {
        private const string Answer = @"232792560";

        [Fact]
        public void Test()
        {
            var actual = GetAnswer();
            Assert.Equal(Answer, actual);
        }

        [Fact]
        public void WellKnownTest()
        {
            var expected = @"2520";
            var actual = GetAnswer(10);
            Assert.Equal(expected, actual);
        }


        public static string GetAnswer(int n = 20)
        {
            var a = new int[n + 1];
            for (var i = 2; i < a.Length; i++)
            {
                if (a[i] < 0)
                {
                    a[i] = 0;
                    continue;
                }
                //
                for (var j = i + i; j < a.Length; j += i)
                {
                    a[j] = -1;
                }
                //
                a[i] = 1;
                for (var j = i * i; j < a.Length; j *= i)
                {
                    a[i]++;
                }
            }
            //
            var result = 1L;
            for (var i = 2; i < a.Length; i++)
            {
                while (a[i] > 0)
                {
                    a[i]--;
                    result *= i;
                }
            }
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}