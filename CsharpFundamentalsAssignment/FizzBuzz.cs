using System;
using System.Collections.Generic;


namespace CsharpFundamentalsAssignment
{
    /**
    * FizzBuzz is an old programming exercise.
    * The goal is to iterate over a range of numbers and print a message about each number's divisibility.
    * <p>
    * The message is generated the following way:
    * *) if the number is divisible by three, the message is `Fizz`
    * *) if the number is divisible by five, the message is `Buzz`
    * *) if the number is divisible by both three and five, the message is `FizzBuzz`
    * *) otherwise, no message is produced
    * <p>
    * The exact message format for this assignment is specified in the `message(n)` method.
    */
    public class FizzBuzz
    {
        /**
         * Checks whether a given int `a` is evenly divisible by a given int `b` or not.
         * For example, `Divides(4, 2)` returns `true` and `Divides(4, 3)` returns `false`.
         *
         * @param a the number to be divided
         * @param b the number to divide by
         * @return `true` if a is evenly divisible by b, `false` otherwise
         * @throws ArgumentException if b is zero
         */
        public static bool Divides(int a, int b)
        {
            if (b == 0)
                throw new ArgumentException();
            else if (a % b == 0)
                return true;
            else
                return false;
        }

        /**
         * Generates a divisibility message for a given number. Returns null if the given number is not divisible by 3 or 5.
         * Message formatting examples:
         * 1 -> null // not divisible by 3 or 5
         * 3 -> "3: Fizz" // divisible by only 3
         * 5 -> "5: Buzz" // divisible by only 5
         * 15 -> "15: FizzBuzz" // divisible by both three and five
         *
         * @param n the number to generate a message for
         * @return a message according to the format above, or null if n is not divisible by either 3 or 5
         */
        public static String Message(int n)
        {

            if (n % 3 == 0 && n % 5 == 0)
                return string.Format("{0}: FizzBuzz",n);
            else if (n % 3 == 0)
                return string.Format("{0}: Fizz",n);
            else if (n % 5 == 0)
                return string.Format("{0}: Buzz",n);
            else
                return null;
        }

        /**
         * Generates an array of messages to print for a given range of numbers.
         * If there is no message for an individual number (i.e., `Message(n)` returns null),
         * it should be excluded from the resulting array.
         *
         * @param start the number to start with (inclusive)
         * @param end the number to end with (exclusive)
         * @return an array of divisibility messages
         * @throws ArgumentException if the given end is less than the given start
         */
        public static String[] Messages(int start, int end)
        {
           if(end < start)
                throw new ArgumentException();
            var s = "";
        
            List<string> arr = new List<string>();

            for (int i = start; i < end; i++)
            {
                s = Message(i);
                if(s != null)
                    arr.Add(s);
            }
            string[] Arr = arr.ToArray();
            return Arr;
        }

        /**
         * For this main method, iterate over the numbers 1 through 115 and print
         * the relevant messages to the console
         */
        public static void Main(String[] args)
        {
            for (int i = 1; i <115; i++)
                Console.Write(Message(i));
        }
    }
}