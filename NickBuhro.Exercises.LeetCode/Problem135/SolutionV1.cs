using System;

namespace LeetCode.Problem135
{
    public class SolutionV1
    {
        public int Candy(int[] ratings)
        {
            var lastIndex = ratings.Length - 1;
            var result = 0;

            var down = false;
            var index = 0;
            var anchorIndex = 0;
            var anchorQty = 0;

            for (;;)
            {
                if (index == lastIndex)
                {
                    var n = index - anchorIndex;
                    var qty = ((n) * (n + 1)) >> 1;
                    qty += Math.Max(anchorQty, n + 1);
                    result += qty;
                    break;
                }
                
                if (ratings[index] == ratings[index + 1])
                {
                    var n = index - anchorIndex;
                    var qty = ((n) * (n + 1)) >> 1;
                    qty += Math.Max(anchorQty, n + 1);
                    result += qty;

                    index++;
                    anchorIndex = index;
                    anchorQty = 0;
                    down = false;
                }
                else if (down)
                {
                    if (ratings[index] < ratings[index + 1])
                    {
                        var n = index - anchorIndex;
                        var qty = (n * (n + 1)) >> 1;
                        qty += Math.Max(anchorQty, n + 1);
                        qty--;
                        result += qty;
                        
                        anchorQty = 0;
                        anchorIndex = index;
                        down = false;
                    }
                    index++;
                }
                else
                {
                    if (ratings[index] > ratings[index + 1])
                    {
                        var n = index - anchorIndex;
                        var qty = (n * (n + 1)) >> 1;
                        result += qty;

                        anchorQty = n + 1;
                        anchorIndex = index;
                        down = true;
                    }
                    index++;
                }
            }

            return result;
        }
    }
}
