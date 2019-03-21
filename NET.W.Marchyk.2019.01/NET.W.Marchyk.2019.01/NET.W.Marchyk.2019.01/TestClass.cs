using NUnit.Framework;
using Day01;
using System.Linq;

namespace Day01
{
    public class SortingTests
    {
        [Test]
        public void QuickSortTest()
        {
            int[] arr1 = new int[] { 5, 4, 2, 1 };
            int[] arr2 = new int[] { 1, 2, 4, 5 };
            int[] resultArr = SortingMethods.QuickSort(arr2, 0, arr2.Length - 1);
            Assert.AreEqual(true, arr2.SequenceEqual(resultArr));
        }
    }
}
