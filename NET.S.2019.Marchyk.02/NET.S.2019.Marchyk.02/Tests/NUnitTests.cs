using System;
using NUnit.Framework;

namespace NET.S._2019.Marchyk._02.Tests
{
    [TestFixture]
    class NUnitTests
    {
        [Test]
        public void DebugTest()
        {
            Assert.AreEqual(1, BitSwapper.InsertNumber(10, 1, 1, 1));
        }
    }
}
