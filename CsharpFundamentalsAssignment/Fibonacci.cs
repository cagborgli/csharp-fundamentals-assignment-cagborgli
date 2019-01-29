using System;

namespace CsharpFundamentalsAssignment
{
    /**
     * The Fibonacci sequence is simply and recursively defined: the first two elements are `1`, and
     * every other element is equal to the sum of its two preceding elements. For example:
     * <p>
     * [1, 1] =>
     * [1, 1, 1 + 1]  => [1, 1, 2] =>
     * [1, 1, 2, 1 + 2] => [1, 1, 2, 3] =>
     * [1, 1, 2, 3, 2 + 3] => [1, 1, 2, 3, 5] =>
     * ...etc
     */
    public class Fibonacci
    {
        /**
         * Calculates the value in the Fibonacci sequence at a given index. For example,
         * `AtIndex(0)` and `AtIndex(1)` should return `1`, because the first two elements of the
         * sequence are both `1`.
         *
         * @param i the index of the element to calculate
         * @return the calculated element
         * @throws ArgumentException if the given index is less than zero
         */
        public static int AtIndex(int i)
        {
            if (i < 0)
                throw new ArgumentException();
            if (i++ <= 1)
                return 1;
            int[] n = new int[i];
            int j = 2;
            n[0] = 1; n[1] = 1;
            while (j < i)
            {
                n[j] = n[j - 2] + n[j - 1];
                j++;
            }
            return n[--j];
        }

        /**
         * Calculates a slice of the fibonacci sequence, starting from a given start index (inclusive) and
         * ending at a given end index (exclusive).
         *
         * @param start the starting index of the slice (inclusive)
         * @param end   the ending index of the slice(exclusive)
         * @return the calculated slice as an array of int elements
         * @throws ArgumentException if either the given start or end is negative, or if the
         *                                  given end is less than the given start
         */
        public static int[] Slice(int start, int end)
        {
            if (start < 0 || end <0|| end <start)
                throw new ArgumentException();
     
            var range = end - start;
            int[] arr= new int[range];
            int w = 0;
            for (var i = start; i < end; i++)
            {
                arr[w] = AtIndex(i);
                w++;
            }
            return arr;
        }

        /**
         * Calculates the beginning of the fibonacci sequence, up to a given count.
         *
         * @param count the number of elements to calculate
         * @return the beginning of the fibonacci sequence, up to the given count, as an array of int elements
         * @throws ArgumentException if the given count is negative
         */
        public static int[] Sequence(int count)
        {
            int[] arr = new int[count];
            if (count < 0)
                throw new ArgumentException();
            else
            {
                
                for (var i = 0; i < count; i++)
                    arr[i] = AtIndex(i);
                
            }
            return arr;

        }
    }
}