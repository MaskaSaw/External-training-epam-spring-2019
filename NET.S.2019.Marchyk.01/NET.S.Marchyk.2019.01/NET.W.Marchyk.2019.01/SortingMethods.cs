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
        /// This method represents a solution for MergeSort algorithm.
        /// </summary>
        /// <param name="inputArray">Array to sort.</param>
        /// <returns>Returns a sorted array.</returns>
        public static int[] MergeSort(int[] inputArray)
        {
            if (inputArray == null)
                throw new ArgumentNullException("Array cannot be null");
            if (inputArray.Length == 0)
                throw new ArgumentException("Array cannot be empty");

            if (inputArray.Length == 1)
                return inputArray;
            int center = inputArray.Length / 2;
            int[] arr1 = new int[center];
            int i;
            for (i = 0; i < arr1.Length; i++)
                arr1[i] = inputArray[i];
            int[] arr2 = new int[inputArray.Length - center];
            for (int j = 0; j < arr2.Length; j++)
            {
                arr2[j] = inputArray[i];
                i++;
            }
            return Merge(MergeSort(arr1), MergeSort(arr2));


        }
        /// <summary>
        /// This is a side method for the MergeSort.
        /// </summary>
        /// <param name="arr1">The left sorted array part.</param>
        /// <param name="arr2">The sorted array part.</param>
        /// <returns>Returns the sorted array part.</returns>
        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int id1 = 0;
            int id2 = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < merged.Length; i++)
            {
                if (id1 < arr1.Length && id2 < arr2.Length)
                {
                    if (arr1[id1] > arr2[id2] && id2 < arr2.Length)
                    {
                        merged[i] = arr2[id2];
                        id2++;
                    }
                    else
                    {
                        merged[i] = arr1[id1];
                        id1++;
                    }
                }
                else
                {
                    if (id2 < arr2.Length)
                    {
                        merged[i] = arr2[id2];
                        id2++;

                    }
                    else
                    {
                        merged[i] = arr1[id1];
                        id1++;
                    }
                }
            }

            return merged;
        }

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


        /// <summary>
        /// This is a side method for the MergeSort.
        /// </summary>
        /// <param name="inputArray">The array to change.</param>
        /// <param name="i">First element index.</param>
        /// <param name="j">Second element index.</param>
        public static void Swap(ref int[] inputArray, int i, int j)
        {
            int buf = inputArray[i];
            inputArray[i] = inputArray[j];
            inputArray[j] = buf;
        }        
    }
}
