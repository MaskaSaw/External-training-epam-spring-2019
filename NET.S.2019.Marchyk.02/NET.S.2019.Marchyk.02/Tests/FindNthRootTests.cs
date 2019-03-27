using System;
using NUnit.Framework;

namespace NET.S._2019.Marchyk._02.Tests
{
    [TestFixture]
    public class FindNthRootTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1,  0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]

        public void FindNthRootTest(double number, int power, double accuracy, double expected)
        {
            double actual = BiggerNumberFInder.FindNthRoot(number, power, accuracy);
            Assert.AreEqual(expected, actual, accuracy);
        }
      ///  public double FindNthRoot(double number, int power, double accuracy) => BiggerNumberFInder.FindNthRoot(number, power, accuracy);
    }
}
