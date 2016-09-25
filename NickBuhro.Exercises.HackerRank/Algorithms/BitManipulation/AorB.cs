using System;

namespace HackerRank.Algorithms.BitManipulation
{
    /// <summary> 
    /// <seealso href="https://www.hackerrank.com/challenges/aorb"/>
    /// </summary>
    public sealed class AorB
    {
        /// <summary>
        /// Array index represents number from 0 to 15.
        /// Array value represents how many bits in the number are set to 1.
        /// </summary>
        private static readonly int[] BitCountMatrix = {
            0, // 0000
            1, // 0001
            1, // 0010
            2, // 0011
            1, // 0100
            2, // 0101
            2, // 0110
            3, // 0111
            1, // 1000
            2, // 1001
            2, // 1010
            3, // 1011
            2, // 1100
            3, // 1101
            3, // 1110
            4  // 1111
        };

        public static void Main()
        {
            var q = int.Parse(Console.ReadLine());
            for (var i = 0; i < q; i++)
            {
                var k = int.Parse(Console.ReadLine());
                var a = Console.ReadLine();
                var b = Console.ReadLine();
                var c = Console.ReadLine();

                string aResult;
                string bResult;
                
                if (Calculate(k, a, b, c, out aResult, out bResult))
                {
                    Console.WriteLine(aResult);
                    Console.WriteLine(bResult);
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
        }

        internal static bool Calculate(int k, string srcA, string srcB, string srcC, out string tgtA, out string tgtB)
        {
            // Prepare vars

            var arrA = srcA.ToCharArray();
            var arrB = srcB.ToCharArray();

            // First round - mandatory manipulations

            for (var i = 0; i < arrA.Length; i++)
            {
                var a = CharToInt(arrA[i]);
                var b = CharToInt(arrB[i]);
                var c = CharToInt(srcC[i]);

                ApplyMandatoryManipulations(ref k, ref a, ref b, c);
                
                arrA[i] = IntToChar(a);
                arrB[i] = IntToChar(b);
            }

            // Check manipulation overflow

            if (k < 0)
            {
                tgtA = null;
                tgtB = null;
                return false;
            }

            // Second round - optional manipulations

            for (var i = 0; i < arrA.Length; i++)
            {
                var a = CharToInt(arrA[i]);
                var b = CharToInt(arrB[i]);
                var c = CharToInt(srcC[i]);

                ApplyOptionalManipulations(ref k, ref a, ref b, c);
                
                arrA[i] = IntToChar(a);
                arrB[i] = IntToChar(b);
            }

            // Prepare results

            tgtA = CharArrayToString(arrA);
            tgtB = CharArrayToString(arrB);
            return true;
        }

        private static void ApplyMandatoryManipulations(ref int k, ref int a, ref int b, int c)
        {
            // A=0 B=0 C=1 -> B:=1
            var m = ~a & ~b & c;
            if (m > 0)
            {
                k -= BitCountMatrix[m];
                b = b | m;
            }

            // A=0 B=1 C=0 -> B:=0
            m = ~a & b & ~c;
            if (m > 0)
            {
                k -= BitCountMatrix[m];
                b = b & ~m;
            }

            // A=1 B=0 C=0 -> A:=0
            m = a & ~b & ~c;
            if (m > 0)
            {
                k -= BitCountMatrix[m];
                a = a & ~m;
            }

            // A=1 B=1 C=0 -> A:=0 B:=0
            m = a & b & ~c;
            if (m > 0)
            {
                k -= (BitCountMatrix[m] << 1);
                a = a & ~m;
                b = b & ~m;
            }
        }

        private static void ApplyOptionalManipulations(ref int k, ref int a, ref int b, int c)
        {
            var ac = a & c;
            if (ac == 0) return;

            for (var m = 8; m > 0; m = m >> 1)
            {
                // A=1 B=1 C=1 -> A:=0
                if ((m & ac & b) != 0)
                {
                    if (k > 0)
                    {
                        k--;
                        a = a & ~m;
                    }
                }
                // A=1 B=0 C=1 -> A:=0 B:=1
                else if ((m & ac & ~b) != 0)
                {
                    if (k > 1)
                    {
                        k -= 2;
                        a = a & ~m;
                        b = b | m;
                    }
                }
            }
        }

        internal static string CharArrayToString(char[] arr)
        {
            var i = 0;
            var iMax = arr.Length - 1;
            while ((arr[i] == '0') && (i < iMax))
            {
                i++;
            }
            return new string(arr, i, arr.Length - i);
        }

        internal static int CharToInt(char c)
        {
            if (char.IsDigit(c))
                return (c - 48);
            return (c - 55);
        }

        internal static char IntToChar(int b)
        {
            if (b < 10)
                return (char) (b + 48);
            return (char) (b + 55);
        }
    }
}
