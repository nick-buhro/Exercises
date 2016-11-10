namespace LeetCode.Problem327
{
    public class SolutionV2
    {
        private class Node
        {
            public static readonly Node Empty = new Node();

            protected Node() { }

            public virtual Node Add(int value)
            {
                return new NodeEx(value);
            }

            public virtual int Count(int lower, int upper)
            {
                return 0;
            }
        }

        private sealed class NodeEx : Node
        {
            private readonly int _value;
            private Node _left;
            private Node _right;

            private int _count;

            public NodeEx(int value)
            {
                _value = value;
                _count = 1;
                _left = Empty;
                _right = Empty;
            }

            public override Node Add(int value)
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
            var heightIndex = Node.Empty;

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
