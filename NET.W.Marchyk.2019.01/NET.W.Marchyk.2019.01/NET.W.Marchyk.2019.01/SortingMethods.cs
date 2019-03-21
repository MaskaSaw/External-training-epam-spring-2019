using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public static class SortingMethods
    {
        /// <summary>
        /// This method represents a solutiion for QuickSort algorythm.
        /// </summary>
        /// <param name="inputArray">Array to sort.</param>
        /// <param name="leftElement">Left border of the sorted array part.</param>
        /// <param name="rightElement">Right border of the sorted array part.</param>
        /// <returns>Returns a sorted array.</returns>
        public static int[] QuickSort(int[] inputArray, int leftElement, int rightElement)
        {
            if (inputArray == null)
                throw new ArgumentNullException("Array cannot be null");
            if (inputArray.Length == 0 || leftElement < 0 || rightElement < 0)
                throw new ArgumentException("Wrong argument value");
           

            int i = leftElement;
            int j = rightElement;
            int centerElement = inputArray[(rightElement - leftElement) / 2 + leftElement];

            do
            {
                while (inputArray[i] < centerElement && i <= rightElement)
                    i++;

                while (inputArray[j] > centerElement && j >= leftElement)
                    j--;

                if (i <= j)
                {
                    Swap(ref inputArray, i, j);
                    i++;
                    j--;
                }
                if (j > leftElement)
                    QuickSort(inputArray, leftElement, j);
                if (i < rightElement)
                    QuickSort(inputArray, i, rightElement);
            }
            while (i <= j);

            return inputArray;
        }

        public static void Swap(ref int[] inputArray, int i, int j)
        {
            int buf = inputArray[i];
            inputArray[i] = inputArray[j];
            inputArray[j] = buf;
        }
    }
}
