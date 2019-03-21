using NUnit.Framework;
using NET.W.Marchyk._2019._01

namespace Tests
{
    public class Tests
    {
       

        [Test]
        public void QuickSortTest()
        {
            int[] arr1 = new int[] { 6, 2, 9, 1, 3, 2 };
            int[] arr2 = new int[] { 1, 2, 2, 3, 6, 9 };
            Assert.AreEqual(arr1, Sorting.MergeSort(arr1));
        }
    }
}