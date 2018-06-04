using System.IO;
using Xunit;

namespace HackerRank.Algorithms.BitManipulation
{
    public sealed class AorBTests
    {
        private struct TestCase
        {
            public int K { get; set; }
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }

            public bool ResultSuccess { get; set; }
            public string ResultA { get; set; }
            public string ResultB { get; set; }
        }

        private TestCase[] ReadTestCaseCollection(string name)
        {
            TestCase[] result;
            var type = typeof (AorBTests);

            var resourceName = type.FullName + "_" + name + "_Input.txt";
            using (var stream = type.Assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(stream))
            {
                var q = int.Parse(sr.ReadLine());
                result = new TestCase[q];
                for (var i = 0; i < q; i++)
                {
                    result[i] = new TestCase
                    {
                        K = int.Parse(sr.ReadLine()),
                        A = sr.ReadLine(),
                        B = sr.ReadLine(),
                        C = sr.ReadLine()
                    };
                }
            }

            resourceName = type.FullName + "_" + name + "_Output.txt";
            using (var stream = type.Assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(stream))
            {
                for (var i = 0; i < result.Length; i++)
                {
                    var s = sr.ReadLine();
                    if (s != "-1")
                    {
                        result[i].ResultSuccess = true;
                        result[i].ResultA = s;
                        result[i].ResultB = sr.ReadLine();
                    }
                }
            }

            return result;
        }
        
        [Theory]
        [InlineData("TestCase00")]
        [InlineData("TestCase20")]
        public void Test(string name)
        {
            var tests = ReadTestCaseCollection(name);
            foreach (var t in tests)
            {
                string aResult;
                string bResult;

                var result = AorB.Calculate(t.K, t.A, t.B, t.C, out aResult, out bResult);

                Assert.Equal(t.ResultSuccess, result);
                if (result)
                {
                    Assert.Equal(t.ResultA, aResult);
                    Assert.Equal(t.ResultB, bResult);
                }
            }
        }
        
        [Theory]
        [InlineData('0', 0)]
        [InlineData('9', 9)]
        [InlineData('A', 10)]
        [InlineData('F', 15)]
        public void ConvertTest(char c, int b)
        {
            Assert.Equal(b, AorB.CharToInt(c));
            Assert.Equal(c, AorB.IntToChar(b));
        }

        [Theory]
        [InlineData("A", "A")]
        [InlineData("AA", "AA")]
        [InlineData("0A", "A")]
        [InlineData("0", "0")]
        [InlineData("00", "0")]
        [InlineData("000", "0")]
        public void CharArrayToStringTest(string source, string target)
        {
            var a = source.ToCharArray();
            Assert.Equal(target, AorB.CharArrayToString(a));
        }
    }
}
