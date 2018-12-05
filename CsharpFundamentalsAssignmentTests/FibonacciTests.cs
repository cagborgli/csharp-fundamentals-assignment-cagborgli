using System;
using System.Linq;
using CsharpFundamentalsAssignment;
using Xunit;

namespace CsharpFundamentalsAssignmentTests
{
    public class FibonacciTests : IDisposable
    {
        private static int _size;
        private static int _window;
        private static int[] _empty;
        private static int[] _seed;
        private static int[] _fib;
        private static int[][] _slices;
        private static int[][] _prefixes;

        public FibonacciTests()
        {
            _size = 100;
            _window = 10;

            _empty = new int[] { };
            _seed = new[] {1, 1};
            _fib = new int[_size];

            Array.Copy(_seed, 0, _fib, 0, _seed.Length);
            for (int i = _seed.Length; i < _size; i++)
            {
                _fib[i] = _fib[i - 1] + _fib[i - 2];
            }

            _slices = new int[_size - _window][];
            for (int i = 0; i < _slices.Length; i++)
            {
                _slices[i] = new int[_window];
                Array.Copy(_fib, i, _slices[i], 0, _window);
            }

            _prefixes = new int[_size][];
            for (int i = 0; i < _size; i++)
            {
                _prefixes[i] = new int[i + 1];
                Array.Copy(_fib, 0, _prefixes[i], 0, i + 1);
            }
        }

        public void Dispose()
        {
            _size = 0;
            _window = 0;
            _empty = null;
            _seed = null;
            _fib = null;
            _slices = null;
            _prefixes = null;
        }

        [Fact]
        public void AtIndexTest()
        {
            for (int i = 0; i < _fib.Length; i++)
            {
                Assert.Equal(_fib[i], Fibonacci.AtIndex(i));
            }
        }

        [Fact]
        public void AtIndexExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.AtIndex(-1));
        }

        [Fact]
        public void SliceTest()
        {
            Assert.True(_empty.OrderBy(n => n).SequenceEqual(Fibonacci.Slice(0, 0).OrderBy(n => n)));
            for (int i = 0; i < _slices.Length; i++)
            {
                Assert.True(_slices[i].OrderBy(n => n).SequenceEqual(Fibonacci.Slice(i, i + _window).OrderBy(n => n)));
            }
        }

        [Fact]
        public void SequenceTest()
        {
            Assert.True(_empty.OrderBy(n => n).SequenceEqual(Fibonacci.Sequence(0).OrderBy(n => n)));
            for (int i = 0; i < _slices.Length; i++)
            {
                Assert.True(_prefixes[i].OrderBy(n => n).SequenceEqual(Fibonacci.Sequence(i + 1).OrderBy(n => n)));
            }
        }

        [Fact]
        public void SequenceExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => Fibonacci.Sequence(-1));
        }
    }
}