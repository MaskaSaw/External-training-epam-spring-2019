using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NET.S._2019.Marchyk._02
{
    class BiggerNumberFInder
    {
        /// <summary>
        /// FindNextBiggerNumber is the method that finds for the given number next bigger number 
        /// which consists of first number's non-repeating digits
        /// </summary>
        /// <param name="number">Input number that we need to find next bigger number for</param>
        /// <returns>Integer result - next bigger number, or null if it is not possible</returns>
        public static int? FindNextBiggerNumber(int number)
        {
            if (number < 0)
                throw new ArgumentException("Value should be positive");

            if (number == int.MaxValue)
                return null;

            string bufString = number.ToString();
            char[] buf = bufString.ToCharArray();
            ArrayList array = new ArrayList();
            Calculate(buf.Length, buf, ref array);

            int[] numbers = new int[array.Count];

            for (int i = 0; i < array.Count; i++)
            {
                numbers[i] = Convert.ToInt32(array[i]);
            }

            int result = number;
            int prevResult = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] > number && numbers[i] <= prevResult)
                {
                    result = numbers[i];
                    prevResult = numbers[i];
                }


            if (result == number)
                return null;
            else
                return result;
        }

        /// <summary>
        /// Thats an additional helping method for FindNextBiggerNumber
        /// </summary>
        /// <param name="range">Range of our number set</param>
        /// <param name="buf">Number set</param>
        /// <param name="array">Array to fill with all variants of number combinations</param>
        public static void Calculate(int range, char[] buf, ref ArrayList array)
        {
            if (range == 0)
                array.Add(string.Join("", buf));

            char bufString = ' ';

            for (int i = 0; i < range; i++)
            {
                Calculate(range - 1, buf, ref array);
                int swapIndex = range % 2 == 0 ? 0 : i;
                bufString = buf[swapIndex];
                buf[swapIndex] = buf[range - 1];
                buf[range - 1] = bufString;
            }
        }


        /// <summary>
        /// Method that counts worktime for function FindNextBiggerNumber
        /// </summary>
        /// <param name="number">Number for counting next bigger number</param>
        /// <returns>Time period spent for the function FindNextBiggerNumber work</returns>
        public static long FindNextBiggerNumberWorkTime(int number)
        {
            Stopwatch watch = Stopwatch.StartNew();
            FindNextBiggerNumber(number);
            return (watch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Method that deletes all numbers from the given sequens which are not 
        /// contain given digit
        /// </summary>
        /// <param name="list">Given set of numbers</param>
        /// <param name="digit">Digit to make sorting</param>
        /// <returns> List<int> newList - list of numbers that contain given digit</returns>
        public static List<int> FilterDigit(List<int> list, int digit)
        {
            if (list == null)
                throw new ArgumentNullException("Input list cannot be null");

            if (digit < 0 || digit > 9)
                throw new ArgumentException("You should use only digints, not numbers");

            List<int> newList = new List<int>();
            foreach (int number in list)
            {
                string buf = number.ToString();
                if (buf.Contains(digit.ToString()))
                    newList.Add(number);
            }

            return newList;
        }

        /// <summary>
        /// Method that findes a root of given number using Newton method with give accuracy
        /// </summary>
        /// <param name="number">Number which root should be found</param>
        /// <param name="power">Power of needed root</param>
        /// <param name="accuracy">Accuracy of calculations</param>
        /// <returns>double next - result of root calculation with given accuracy</returns>
        public static double FindNthRoot(double number, int power, double accuracy)
        {
            if (accuracy <= 0 || accuracy >= 1)
            {
                throw new ArgumentException("Accuracy should be correct");
            }

            if (power % 2 == 0 && number < 0)
            {
                throw new ArgumentException("Power should be correct");
            }

            if (power <= 0)
            {
                throw new ArgumentException("Power should be more then zero");
            }

            if (power == 1)
            {
                return number;
            }

            double current = 1;
            double next = SetNewValue(current, power, number);

            while (Math.Abs(current - next) >= accuracy)
            {
                current = next;
                next = SetNewValue(current, power, number);
            }

            return next;
        }

        /// <summary>
        /// Method that set new value for the Newton algorithm.
        /// </summary>
        /// <param name="current">Current value of needed root value.</param>
        /// <param name="power">Root degree.</param>
        /// <param name="number">Needed root value.</param>
        /// <returns>New value for the Newton algorithm.</returns>
        private static double SetNewValue(double current, int power, double number)
        {
            double result = (((power - 1) * current) + (number / Math.Pow(current, power - 1))) / power;
            return result;
        }

    }
}
