using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorting
{
        public class JaggedArray
        {
            /// <summary>
            /// Constructor of JaggedArray
            /// </summary>
            /// <param name="array">Initializing array</param>
            public JaggedArray(int[][] array)
            {
                Array = array ?? throw new ArgumentNullException(nameof(array));
            }
            public int[][] Array { get; }

            /// <summary>
            /// Method for swapping elements in JaggedArray
            /// </summary>
            /// <param name="arr1">First array</param>
            /// <param name="arr2">Second array</param>
            public void Swap(ref int[] arr1, ref int[] arr2)
            {
                int[] buff = arr1;
                arr1 = arr2;
                arr2 = buff;
            }

            /// <summary>
            /// Method for searching min element in a row
            /// </summary>
            /// <param name="array"></param>
            /// <returns>Minimal element in a row</returns>
            public int Min(int[] array)
            {
                int min = int.MaxValue;
                foreach (int item in array)
                {
                    if (item < min)
                    {
                        min = item;
                    }
                }
                return min;
            }

            /// <summary>
            /// Method for searching max element in a row
            /// </summary>
            /// <param name="array"></param>
            /// <returns>Maximal element in a row</returns>
            public int Max(int[] array)
            {
                int max = int.MinValue;
                foreach (int item in array)
                {
                    if (item > max)
                    {
                        max = item;
                    }
                }
                return max;
            }

            /// <summary>
            /// Method for finding summ of elements
            /// </summary>
            /// <param name="array"></param>
            /// <returns>Sum of all elements in a row</returns>
            public int Sum(int[] array)
            {
                int sum = 0;
                foreach (int element in array)
                {
                    sum += element;
                }
                return sum;
            }
            
            /// <summary>
            /// Method for sorting by sum of elements in a row
            /// </summary>
            public void SortBySum()
            {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = Array.Length - 1; j > i; j--)
                {
                    if (Sum(Array[i]) < Sum(Array[j]))
                    {
                        Swap(ref Array[i], ref Array[j]);
                    }
                }
            }
        }
            
            /// <summary>
            /// Method for sorting by maximal element in a row
            /// </summary>
            public void SortByMax()
            {
                for (int i = 0; i < Array.Length; i++)
                {
                    for (int j = Array.Length - 1; j > i; j--)
                    {
                        if (Max(Array[i]) < Max(Array[j]))
                        {
                            Swap(ref Array[i], ref Array[j]);
                        }
                    }
                }
            }
            
            /// <summary>
            /// Method for sorting by minimal element in a row
            /// </summary>
            public void SortByMin()
            {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = Array.Length - 1; j > i; j--)
                {
                    if (Min(Array[i]) < Min(Array[j]))
                    {
                        Swap(ref Array[i], ref Array[j]);
                    }
                }
            }
        }
        }
}
