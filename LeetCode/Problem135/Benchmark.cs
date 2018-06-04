using System;
using System.Diagnostics;
using System.Linq;

namespace LeetCode.Problem135
{
    internal static class Benchmark
    {
        public static void Run()
        {
            Console.WriteLine("135. Candy - Benchmark Tool");

            var result = GetResults();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Iteration | V1       | V2");
            Console.WriteLine("----------+----------+----------");
            for (var i = 0; i < result[0].Length; i++)
            {
                Console.WriteLine(" {0,-8} |{1,9} |{2,9}", i + 1, result[0][i], result[1][i]);
            }
            Console.WriteLine("----------+----------+----------");
            Console.WriteLine(" MIN      |{0,9} |{1,9}", result[0].Min(), result[1].Min());
            
            var min = Math.Min(result[0].Min(), result[1].Min());
            Console.WriteLine(" %        |{0,9:F0} |{1,9:F0}", 
                100 * result[0].Min() / min,
                100 * result[1].Min() / min);
        }

        private static long[][] GetResults(int iterations = 5)
        {
            var results = new[]
            {
                new long[iterations],
                new long[iterations]
            };

            var testCase = Tests.GetTimeLimitTestRatings();
            var v1 = new SolutionV1();
            var v2 = new SolutionV2();

            var sw = new Stopwatch();

            Console.Error.WriteLine(v1.Candy(new[] {1}));
            Console.Error.WriteLine(v2.Candy(new[] {1}));

            for (var i = 0; i < iterations; i++)
            {
                sw.Restart();
                var output = v1.Candy(testCase);
                sw.Stop();
                results[0][i] = sw.ElapsedTicks;
                Console.Error.WriteLine(output);

                sw.Restart();
                output = v2.Candy(testCase);
                sw.Stop();
                results[1][i] = sw.ElapsedTicks;
                Console.Error.WriteLine(output);
            }

            return results;
        }
    }
}
