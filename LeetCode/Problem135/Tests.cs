using System.IO;
using System.Linq;
using Xunit;

namespace LeetCode.Problem135
{
    public class Tests
    {
        private readonly SolutionV2 _problem = new SolutionV2();

        [Fact]
        public void MyTest()
        {
            // Candies:     {1, 4, 3, 2, 1}
            int[] ratings = {1, 5, 4, 3, 2};
            const int expected = 11;
            
            var actual = _problem.Candy(ratings);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test01()
        {
            // Candies:     { 1, 2, 1 }
            int[] ratings = { 1, 2, 2 };
            const int expected = 4;
            
            var actual = _problem.Candy(ratings);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TimeLimitTest()
        {
            var ratings = GetTimeLimitTestRatings();
            const int expected = 40764;

            var actual = _problem.Candy(ratings);
            
            Assert.Equal(expected, actual);
        }

        public static int[] GetTimeLimitTestRatings()
        {
            var type = typeof(Tests);

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
