using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.S._2019.Marchyk._02.Tests
{
    [TestClass]
    public class BitSwapperMSUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentTest()
        {
            BitSwapper.InsertNumber(0, 0, 3, 1);   
        }

        [TestMethod]
        public void MainTest()
        {
            int result = BitSwapper.InsertNumber(5, 3, 0, 2);
            int expected = 7;
            Assert.AreEqual(expected, result);

            result = BitSwapper.InsertNumber(5, 2, 0, 0);
            expected = 4;
            Assert.AreEqual(expected, result);
        }

    }
}
