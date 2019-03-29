using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class GCD
    {

        #region ClassicalSearchingByEuclid

        /// <summary>
        /// Classical Euclidean algorythm of computing GCD for 2 numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The GCD of two given numbers.</returns>
        public static int Euclide(int a, int b)
        {
            if (a == 0)
                return b;

            if (b == 0)
                return a;

            a = Math.Abs(a); b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }

        /// <summary>
        /// Algorithm for computing GCD for any amount of numbers in the array <paramref name="numbers"/>.
        /// </summary>
        /// <param name="numbers">An array of numbers. Must not be null and must have at least two elements.</param>
        /// <returns>The GCD of all numbers in the array.</returns>
        public static int Euclide(params int[] numbers)
        {
            ArgumentCheck(numbers);

            int i, gcd = numbers[0];
            for (i = 0; i < numbers.Length - 1; i++)
                gcd = Euclide(gcd, numbers[i + 1]);
            return gcd;
        }


        /// <summary>
        /// The GCD computing for any amount of numbers with running time out parameter.
        /// </summary>
        /// <param name="time">The algorythm running time in long representation.</param>
        /// <param name="numbers">All numbers for cumputing in algorithm.</param>
        /// <returns>The GCD result of computing.</returns>
        public static long TimeOfEuclide(out long time, params int[] numbers)
        {
            var sw = Stopwatch.StartNew();
            int euclide = Euclide(numbers);
            time = sw.ElapsedMilliseconds;

            return euclide;
        }

        #endregion

        /// <summary>
        /// Calculates the GCD of <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <remarks>
        /// Uses the binary Euclid algorithm for calculating the GCD.
        /// </remarks>
        /// <param name="a">A number.</param>
        /// <param name="b">A number.</param>
        /// <returns>The GCD of <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int Stein(int a, int b)
        {
            int? result = null;

            if (b == 0 || a == b)
                result = a;

            else if (a == 0)
                result = b;

            else if (a == 1 || b == 1)
                result = 1;

            if (result != null)
                return Math.Abs((int)result);

            if ((a & 1) == 0)
                result = ((b & 1) == 0)
                    ? Stein(a >> 1, b >> 1) << 1
                    : Stein(a >> 1, b);
            else
                result = ((b & 1) == 0)
                    ? Stein(a, b >> 1)
                    : Stein(b, a > b ? a - b : b - a);

            return Math.Abs((int)result);
        }

        /// <summary>
        /// Algorithm for computing GCD using Stein algorithm
        /// for any amount of numbers in the array <paramref name="numbers"/>.
        /// </summary>
        /// <param name="numbers">An array of numbers. Must not be null and must have at least two elements.</param>
        /// <returns>The GCD of all numbers in the array.</returns>
        public static int Stein(params int[] numbers)
        {
            ArgumentCheck(numbers);

            int i, gcd = numbers[0];
            for (i = 0; i < numbers.Length - 1; i++)
                gcd = Stein(gcd, numbers[i + 1]);
            return gcd;
        }

        /// <summary>
        /// Helping function for checking argument exceptions.
        /// </summary>
        /// <param name="numbers">Arguments to check.</param>
        private static void ArgumentCheck(int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("You should input arguments");

            if (numbers.Length < 2)
                throw new ArgumentException("Number of arguments should be 2 or more");

        }

        /// <summary>
        /// The GCD computing by Stein algorithm for any amount of numbers with running time out parameter.
        /// </summary>
        /// <param name="time">The algorythm running time in long representation.</param>
        /// <param name="numbers">All numbers for cumputing in algorithm.</param>
        /// <returns>The GCD result of computing.</returns>
        public static long TimeOfStein(out long time, params int[] numbers)
        {
            var sw = Stopwatch.StartNew();
            int stein = Stein(numbers);
            time = sw.ElapsedMilliseconds;

            return stein;
        }
    }
}
