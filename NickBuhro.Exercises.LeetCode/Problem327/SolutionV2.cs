namespace LeetCode.Problem327
{
    public class SolutionV2
    {
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            var result = 0;
            long height = 0;
            var heightIndex = new NodeEx(0);

            foreach (var n in nums)
            {
                height += n;
                result += heightIndex.Count(height - upper, height - lower);
                heightIndex.Add(height);
            }

            return result;
        }

        private class Node
        {
            public static readonly Node Empty = new Node();

            protected Node() { }

            public virtual Node Add(long value)
            {
                return new NodeEx(value);
            }

            public virtual int Count(long lower, long upper)
            {
                return 0;
            }
        }

        private sealed class NodeEx : Node
        {
            private readonly long _value;
            private Node _left;
            private Node _right;

            private int _count;

            public NodeEx(long value)
            {
                _value = value;
                _count = 1;
                _left = Empty;
                _right = Empty;
            }

            public override Node Add(long value)
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

            public override int Count(long lower, long upper)
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
    }
}
