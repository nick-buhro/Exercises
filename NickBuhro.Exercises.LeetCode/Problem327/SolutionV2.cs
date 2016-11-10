namespace LeetCode.Problem327
{
    public class SolutionV2
    {
        private class ZeroNode
        {
            public static ZeroNode Empty = new ZeroNode();

            public virtual ZeroNode Add(int value)
            {
                return new Node(value);
            }

            public virtual int Count(int lower, int upper)
            {
                return 0;
            }
        }

        private sealed class Node : ZeroNode
        {
            private readonly int _value;
            private ZeroNode _left;
            private ZeroNode _right;

            private int _count;

            public Node(int value)
            {
                _value = value;
                _count = 1;
                _left = Empty;
                _right = Empty;
            }

            public override ZeroNode Add(int value)
            {
                if (value < _value)
                {
                    _left = _left.Add(value);
                }
                else if (value > _value)
                {
                    _right = _right.Add(value);
                }
                else
                {
                    _count++;
                }
                return this;
            }

            public override int Count(int lower, int upper)
            {
                if (_value < lower)
                {
                    return _right.Count(lower, upper);
                }
                if (_value > upper)
                {
                    return _left.Count(lower, upper);
                }
                if (_value == lower)
                {
                    return _count + _right.Count(lower, upper);
                }
                if (_value == upper)
                {
                    return _count + _left.Count(lower, upper);
                }

                return _count + _left.Count(lower, upper) + _right.Count(lower, upper);
            }
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            if ((nums == null) || (nums.Length == 0))
                return 0;

            var result = 0;
            var height = 0;
            var heightIndex = ZeroNode.Empty;

            foreach (var n in nums)
            {
                if ((lower <= n) && (n <= upper))
                    result++;

                height += n;
                result += heightIndex.Count(height - upper, height - lower);
                heightIndex = heightIndex.Add(height);
            }

            return result;
        }
    }
}
