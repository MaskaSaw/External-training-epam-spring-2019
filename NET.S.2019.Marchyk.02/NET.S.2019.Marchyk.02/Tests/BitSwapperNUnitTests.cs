using System;
using NUnit.Framework;

namespace NET.S._2019.Marchyk._02.Tests
{
    [TestFixture]
    class BitSwapperNUnitTests
    {
        [Test]
        public void MainTest()
        {
            int result = BitSwapper.InsertNumber(15, 15, 0, 0);
            int expected = 15;
            Assert.AreEqual(expected, result);

            result = BitSwapper.InsertNumber(8, 15, 0, 0);
            expected = 9;
            Assert.AreEqual(expected, result);

            result = BitSwapper.InsertNumber(8, 15, 3, 8);
            expected = 120;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ArgumentTest()
        {
            Assert.Throws(typeof(ArgumentException), () => BitSwapper.InsertNumber(0, 0, 3, 1));
        }
    }
}
