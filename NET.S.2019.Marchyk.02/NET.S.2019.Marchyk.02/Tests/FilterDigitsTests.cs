using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace NET.S._2019.Marchyk._02.Tests
{
    [TestFixture]
    class FilterDigitsTests
    {
        [Test]
        public void WorkingTests()
        {
            var inputList = new List<int>() { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int digit = 7;
            var result = BiggerNumberFInder.FilterDigit(inputList, digit);
            var expected = new List<int>() { 7, 7, 70, 17 };
            Assert.AreEqual(expected, result);
        }   
        
        [Test]
        public void NullTest()
        {
            Assert.Throws(typeof(ArgumentNullException), () => BiggerNumberFInder.FilterDigit(null, 2));
        }
    }
}
