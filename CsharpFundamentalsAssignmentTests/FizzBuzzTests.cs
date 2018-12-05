using System;
using System.Linq;
using CsharpFundamentalsAssignment;
using Xunit;

namespace CsharpFundamentalsAssignmentTests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void DividesTest()
        {
            Assert.True(FizzBuzz.Divides(3, 3));
            Assert.True(FizzBuzz.Divides(5, 5));
            Assert.True(FizzBuzz.Divides(15, 3));
            Assert.True(FizzBuzz.Divides(15, 5));

            Assert.False(FizzBuzz.Divides(1, 3));
            Assert.False(FizzBuzz.Divides(2, 3));
            Assert.False(FizzBuzz.Divides(4, 3));
            Assert.False(FizzBuzz.Divides(5, 3));

            Assert.False(FizzBuzz.Divides(1, 5));
            Assert.False(FizzBuzz.Divides(2, 5));
            Assert.False(FizzBuzz.Divides(3, 5));
            Assert.False(FizzBuzz.Divides(4, 5));
        }

        [Fact]
        public void DividesExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => FizzBuzz.Divides(0, 0));
        }

        [Fact]
        public void MessageTest()
        {
            Assert.Equal("3: Fizz", FizzBuzz.Message(3));
            Assert.Equal("5: Buzz", FizzBuzz.Message(5));
            Assert.Equal("15: FizzBuzz", FizzBuzz.Message(15));
        }

        [Fact]
        public void MessagesTest()
        {
            Assert.True(new string[] { }.OrderBy(n => n).SequenceEqual(FizzBuzz.Messages(3, 3).OrderBy(n => n)));
            Assert.True(new[] {"3: Fizz"}.OrderBy(n => n).SequenceEqual(FizzBuzz.Messages(3, 4).OrderBy(n => n)));
            Assert.True(new[] {"3: Fizz"}.OrderBy(n => n).SequenceEqual(FizzBuzz.Messages(3, 5).OrderBy(n => n)));
            Assert.True(new[] {"3: Fizz", "5: Buzz"}.OrderBy(n => n).SequenceEqual(FizzBuzz.Messages(3, 6).OrderBy(n => n)));
            Assert.True(new[] {"3: Fizz", "5: Buzz", "6: Fizz"}.OrderBy(n => n).SequenceEqual(FizzBuzz.Messages(3, 7).OrderBy(n => n)));
            Assert.True(new[] {"12: Fizz", "15: FizzBuzz"}.OrderBy(n => n).SequenceEqual(FizzBuzz.Messages(12, 16).OrderBy(n => n)));
        }

        [Fact]
        public void MessagesExceptionTest()
        {
            Assert.Throws<ArgumentException>(() => FizzBuzz.Messages(20, 19));
        }
    }
}