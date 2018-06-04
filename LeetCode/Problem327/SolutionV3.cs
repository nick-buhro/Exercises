using System;

namespace LeetCode.Problem327
{
    public class SolutionV3
    {
        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            var result = 0;
            long height = 0;
            var heightIndex = new Node(0);

            foreach (var n in nums)
            {
                height += n;
                result += heightIndex.Count(height - upper, height - lower);
                heightIndex = heightIndex.Add(height);
            }

            return result;
        }

        private class Node
        {
            private readonly long _value;
            private Node _left;
            private Node _right;
            private int _count;
            private int _fullCount;
            private int _level;

            protected Node() { }

            public Node(long value)
            {
                _value = value;
                _count = 1;
                _fullCount = 1;
                _level = 1;
                _left = EmptyNode.Instance;
                _right = EmptyNode.Instance;
            }
            
            public virtual Node Add(long value)
            {
                _fullCount++;
                if (_value == value)
                {
                    _count++;
                    return this;
                }
                
                if (value < _value)
                {
                    _left = _left.Add(value);
                }
                else
                {
                    _right = _right.Add(value);
                }
                _level = Math.Max(_left._level, _right._level) + 1;
                return Balance();
            }

            private Node Balance()
            {
                var delta = _right._level - _left._level;
                if (delta == 2)
                {
                    var a = this;
                    var b = _right;
                    var c = b._left;
                    if (c._level <= b._right._level)
                    {
                        // Small left rotation
                        b._left = a;
                        a._right = c;
                        a.RecalculateFullCount();
                        b.RecalculateFullCount();
                        a.RecalculateLevel();
                        return b;
                    }
                    // Big left rotation
                    a._right = c._left;
                    b._left = c._right;
                    c._left = a;
                    c._right = b;
                    a.RecalculateFullCount();
                    b.RecalculateFullCount();
                    c.RecalculateFullCount();
                    a.RecalculateLevel();
                    b.RecalculateLevel();
                    c.RecalculateLevel();
                    return c;
                }
                if (delta == -2)
                {
                    var a = this;
                    var b = _left;
                    var c = b._right;
                    if (c._level <= b._left._level)
                    {
                        // Small right rotation
                        b._right = a;
                        a._left = c;
                        a.RecalculateFullCount();
                        b.RecalculateFullCount();
                        a.RecalculateLevel();
                        return b;
                    }
                    // Big right rotation
                    a._left = c._right;
                    b._right = c._left;
                    c._right = a;
                    c._left = b;
                    a.RecalculateFullCount();
                    b.RecalculateFullCount();
                    c.RecalculateFullCount();
                    a.RecalculateLevel();
                    b.RecalculateLevel();
                    c.RecalculateLevel();
                    return c;
                }

                return this;
            }

            private void RecalculateFullCount()
            {
                _fullCount = _count + _left._fullCount + _right._fullCount;
            }

            private void RecalculateLevel()
            {
                _level = Math.Max(_left._level, _right._level) + 1;
            }

            public virtual int Count(long lower, long upper)
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
                    return _count + _right.CountTo(upper);
                }
                if (_value == upper)
                {
                    return _count + _left.CountFrom(lower);
                }
                return _left.CountFrom(lower) + _count + _right.CountTo(upper);
            }

            protected virtual int CountTo(long upper)
            {
                if (_value > upper)
                {
                    return _left.CountTo(upper);
                }

                var result = _count + _left._fullCount;
                if (_value < upper)
                    result += _right.CountTo(upper);
                return result;
            }

            protected virtual int CountFrom(long lower)
            {
                if (_value < lower)
                {
                    return _right.CountFrom(lower);
                }

                var result = _count + _right._fullCount;
                if (_value > lower)
                    result += _left.CountFrom(lower);
                return result;
            }
        }

        private sealed class EmptyNode : Node
        {
            public static readonly EmptyNode Instance = new EmptyNode();

            public override Node Add(long value)
            {
                return new Node(value);
            }

            public override int Count(long lower, long upper)
            {
                return 0;
            }

            protected override int CountFrom(long lower)
            {
                return 0;
            }

            protected override int CountTo(long upper)
            {
                return 0;
            }
        }
    }
}
