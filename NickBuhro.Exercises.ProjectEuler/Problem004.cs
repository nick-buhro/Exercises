using System;
using System.Globalization;
using Xunit;

namespace NickBuhro.Exercises.ProjectEuler
{
    /// <summary>
    /// Largest palindrome product
    /// 
    /// A palindromic number reads the same both ways. 
    /// The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    ///
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// 
    /// <seealso href="https://projecteuler.net/problem=4"/>
    /// </summary>
    public sealed class Problem004
    {
        [Theory]
        [InlineData(2, 9009)]
        [InlineData(3, 906609)]
        public void Test(int digits, int expectedAnswer)
        {
            var actual = GetAnswer(digits);
            Assert.Equal(expectedAnswer, actual);
        }
        

        public static int GetAnswer(int digits = 3)
        {
            var result = 0;

            var lo = Convert.ToInt32(Math.Pow(10, digits - 1));
            var hi = lo*10 - 1;
            
            for (var i = hi; i >= lo; i--)
            {
                for (var j = i; j >= lo; j--)
                {
                    var value = i*j;
                    if (IsPolindrome(value))
                    {
                        lo = j + 1;
                        if (result < value)
                        {
                            result = value;
                        }
                    }
                }
            }

            return result;
        }

        private static bool IsPolindrome(int value)
        {
            var s = value.ToString(CultureInfo.InvariantCulture);

            var i = 0;
            var j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }
                i++;
                j--;
            }

            return true;
        }
    }
}
