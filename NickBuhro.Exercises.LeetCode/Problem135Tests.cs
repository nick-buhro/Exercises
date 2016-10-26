using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace LeetCode
{
    public class Problem135Tests
    {
        [Fact]
        public void MyTest()
        {
            // Candies:     {1, 4, 3, 2, 1}
            int[] ratings = {1, 5, 4, 3, 2};
            const int expected = 11;

            var p = new Problem135();
            var actual = p.Candy(ratings);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test01()
        {
            // Candies:     { 1, 2, 1 }
            int[] ratings = { 1, 2, 2 };
            const int expected = 4;

            var p = new Problem135();
            var actual = p.Candy(ratings);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimeLimitTest()
        {
            var ratings = GetTimeLimitTestRatings();
            const int expected = 40764;

            var p = new Problem135();
            var actual = p.Candy(ratings);
            
            Assert.Equal(expected, actual);
        }

        private static int[] GetTimeLimitTestRatings()
        {
            var type = typeof(Problem135Tests);

            var resourceName = type.FullName + "_TimeLimitTest.txt";
            using (var stream = type.Assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(stream))
            {
                return sr
                    .ReadToEnd()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
        }
    }
}
