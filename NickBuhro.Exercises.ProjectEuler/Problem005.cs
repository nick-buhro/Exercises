using System;
using Xunit;

namespace NickBuhro.Exercises.ProjectEuler
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
        [Theory]
        [InlineData(10, 2520)]
        [InlineData(20, 232792560)]
        public void Test(int n, long expected)
        {
            var actual = GetFastAnswer(n);
            Assert.Equal(expected, actual);
        }

        public static long GetAnswer(int n = 20)
        {
            for (var i = n; i < int.MaxValue; i++)
            {
                var fail = false;
                for (var j = 2; j <= n; j++)
                {
                    if ((i % j) != 0)
                    {
                        fail = true;
                        break;
                    }
                }
                if (!fail)
                {
                    return i;
                }
            }
            throw new AnswerNotFoundException();
        }

        public static long GetFastAnswer(int n = 20)
        {
            var a = new int[n+1];
            for (var i = 2; i < a.Length; i++)
            {
                if (a[i] < 0)
                {
                    a[i] = 0;
                    continue;
                }
                //
                for (var j = i+i; j < a.Length; j += i)
                {
                    a[j] = -1;
                }
                //
                a[i] = 1;
                for (var j = i*i; j < a.Length; j *= i)
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
            return result;
        }
    }
}