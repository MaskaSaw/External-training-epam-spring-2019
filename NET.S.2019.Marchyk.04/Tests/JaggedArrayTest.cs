using System;
using NUnit.Framework;

namespace BubbleSorting
{
    [TestFixture]
    class JaggedArrayTest
    {
        [Test]
        public void SortByMaxTest()
        {
            int[][] array = new int[3][];
            array[0] = new int[] { 1, 3, 2, 7, 9 };
            array[1] = new int[] { 4, 9, 1};
            array[2] = new int[] { 1, 4, 2, 15 };

            JaggedArray jaggedArray = new JaggedArray(array);
            jaggedArray.SortByMax();

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 1, 4, 2, 15 };
            expectedArray[1] = new int[] { 4, 9, 1 };
            expectedArray[2] = new int[] { 1, 3, 2, 7, 9 };
            
            JaggedArray expectedJaggedArray = new JaggedArray(expectedArray);

            Assert.AreEqual(expectedJaggedArray.Array, jaggedArray.Array);
        }

        [Test]
        public void SortByMinTest()
        {
            int[][] array = new int[3][];
            array[0] = new int[] { 10, 3, 2, 7, 9 };
            array[1] = new int[] { 4, 9, 1 };
            array[2] = new int[] { 7, 4, 3, 15 };

            JaggedArray jaggedArray = new JaggedArray(array);
            jaggedArray.SortByMin();

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 7, 4, 3, 15 };
            expectedArray[1] = new int[] { 10, 3, 2, 7, 9 };
            expectedArray[2] = new int[] { 4, 9, 1 };

            JaggedArray expectedJaggedArray = new JaggedArray(expectedArray);

            Assert.AreEqual(expectedJaggedArray.Array, jaggedArray.Array);
        }

        [Test]
        public void SortBySumTest()
        {
            int[][] array = new int[3][];
            array[0] = new int[] { 10, 10, 10 };
            array[1] = new int[] { 1, 1, 1, 1, 1, 1 };
            array[2] = new int[] { 2, 2, 2, 2, 2};

            JaggedArray jaggedArray = new JaggedArray(array);
            jaggedArray.SortBySum();

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 10, 10, 10 };           
            expectedArray[1] = new int[] { 2, 2, 2, 2, 2 };
            expectedArray[2] = new int[] { 1, 1, 1, 1, 1, 1 };

            JaggedArray expectedJaggedArray = new JaggedArray(expectedArray);

            Assert.AreEqual(expectedJaggedArray.Array, jaggedArray.Array);
        }
    }
}
