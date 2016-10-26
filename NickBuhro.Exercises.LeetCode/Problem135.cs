using System;

namespace LeetCode
{
    /// <summary>
    /// 135. Candy
    /// 
    /// There are N children standing in a line. Each child is assigned a rating value.
    /// 
    /// You are giving candies to these children subjected to the following requirements:
    /// - Each child must have at least one candy.
    /// - Children with a higher rating get more candies than their neighbors.
    ///
    /// What is the minimum candies you must give?
    /// 
    /// <seealso href="https://leetcode.com/problems/candy/"/>
    /// </summary>
    public class Problem135
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
                
                var cmp = ratings[index].CompareTo(ratings[index + 1]);
                
                if (cmp == 0)
                {
                    var n = index - anchorIndex;
                    var qty = ((n) * (n + 1)) >> 1;
                    qty += Math.Max(anchorQty, n + 1);
                    result += qty;

                    index++;
                    anchorIndex = index;
                    anchorQty = 0;
                    down = false;
                    continue;
                }

                if (down)
                {
                    if (cmp == -1)
                    {
                        var n = index - anchorIndex;
                        var qty = ((n) * (n + 1)) >> 1;
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
                    if (cmp == 1)
                    {
                        var n = index - anchorIndex;
                        var qty = ((n) * (n + 1)) >> 1;
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
