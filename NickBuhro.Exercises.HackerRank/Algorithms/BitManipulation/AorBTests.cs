using System;
using System.IO;
using Xunit;

namespace HackerRank.Algorithms.BitManipulation
{
    public sealed class AorBTests
    {
        private struct TestCasePart
        {
            public int K { get; set; }
            public string A { get; set; }
            public string B { get; set; }
            public string C { get; set; }

            public bool ResultSuccess { get; set; }
            public string ResultA { get; set; }
            public string ResultB { get; set; }
        }

        private TestCasePart[] ReadTestCase(string name)
        {
            TestCasePart[] result;
            var type = typeof (AorBTests);

            var resourceName = type.FullName + "_" + name + "_Input.txt";
            using (var stream = type.Assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(stream))
            {
                var q = int.Parse(sr.ReadLine());
                result = new TestCasePart[q];
                for (var i = 0; i < q; i++)
                {
                    result[i] = new TestCasePart
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
        
        public void Test(string testName)
        {
            var testCaseCollection = ReadTestCase(testName);
            foreach (var tc in testCaseCollection)
            {
                string aResult;
                string bResult;

                var result = AorB.Calculate(tc.K, tc.A, tc.B, tc.C, out aResult, out bResult);

                Assert.Equal(tc.ResultSuccess, result);
                if (result)
                {
                    Assert.Equal(tc.ResultA, aResult);
                    Assert.Equal(tc.ResultB, bResult);
                }
            }
        }

        [Fact]
        public void Test00()
        {
            Test("TestCase00");
        }

        [Fact]
        public void Test20()
        {
            Test("TestCase20");
        }


        [Theory]
        [InlineData('0', 0)]
        [InlineData('9', 9)]
        [InlineData('A', 10)]
        [InlineData('F', 15)]
        public void ConvertTest(char c, int b)
        {
            Assert.Equal(AorB.CharToInt(c), b);
            Assert.Equal(AorB.IntToChar(b), c);
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
            Assert.Equal(AorB.CharArrayToString(a), target);
        }
    }
}
