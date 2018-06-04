using System.Collections.Generic;
using Xunit;

namespace Euler.MyMath
{
    public sealed class DividerCountTable
    {
        private int[] _table;
        
        public int this[int number] => _table[number];

        public DividerCountTable(int maxNumber)
        {            
            var temp = new int[maxNumber + 1];
            var primes = new List<int>();

            // Calculate prime numbers

            for (var p = 2; p < temp.Length; )
            {
                primes.Add(p);

                for (var i = p + p; i < temp.Length; i += p)
                    temp[i] = 1;

                do
                {
                    p++;
                } while ((p < temp.Length) && (temp[p] == 1));
            }           

            // Init table

            _table = new int[temp.Length];
            for (var i = 0; i < _table.Length; i++)
                _table[i] = 1;

            // Update table

            foreach (var p in primes)
            {
                for (var j = p; j < temp.Length; j += p)
                    temp[j] = 1;

                for (var pp = (long)p*p; pp < temp.Length; pp *= p)
                {
                    for (var j = pp; j < temp.Length; j += pp)
                        temp[j] += 1;
                }

                for (var j = p; j < temp.Length; j += p)
                    _table[j] *=  (temp[j] + 1);
            }            
        }        
    }
    
    public sealed class DividerCountTableTests
    {
        private static DividerCountTable _table = new DividerCountTable(300);

        [Theory]
        [InlineData(3, 2)]
        [InlineData(6, 4)]
        [InlineData(28, 6)]
        [InlineData(300, 18)]
        public void Test(int number, int expected)
        {   
            Assert.Equal(expected, _table[number]);
        }
    }
}
