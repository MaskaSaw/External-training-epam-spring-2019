namespace Algorithms.Tests
{
    using System;
    using Algorithms;
    using NUnit.Framework;

    public class GCDTests
    {
        [TestCase(10, 20, ExpectedResult = 10)]
        [TestCase(10, 0, ExpectedResult = 10)]
        [TestCase(-1, 20, ExpectedResult = 1)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-10, -20, ExpectedResult = 10)]
        public int EuclideTestsForTwoNumbers(int a, int b)
        {
            return GCD.Euclide(a, b);
        }

        [TestCase(10, 20, 30, ExpectedResult = 10)]
        [TestCase(400, 20, -200, ExpectedResult = 20)]
        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(10, 20, 30, 40, ExpectedResult = 10)]
        public int EuclideTestsForAnyNumbers(params int[] numbers)
        {
            return GCD.Euclide(numbers);
        }


        [Test]
        public void EuclideTests_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => GCD.Euclide(null));
        }

        [Test]
        public void EuclideTests_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => GCD.Euclide());
        }

        [TestCase(10, 20, ExpectedResult = 10)]
        [TestCase(0, 20, ExpectedResult = 20)]
        [TestCase(10, 0, ExpectedResult = 10)]
        [TestCase(-1, 20, ExpectedResult = 1)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-10, -20, ExpectedResult = 10)]
        public int SteinTestsForTwoNumbers(int a, int b)
        {
            return GCD.Stein(a, b);
        }

        [TestCase(10, 20, 30, ExpectedResult = 10)]
        [TestCase(8, int.MaxValue, 100, ExpectedResult = 1)]
        [TestCase(8, 0, 100, 60, ExpectedResult = 4)]
        [TestCase(34, 17, 459, ExpectedResult = 17)]
        [TestCase(400, 20, -200, ExpectedResult = 20)]
        [TestCase(10, 20, 30, 40, ExpectedResult = 10)]
        public int SteinTestsForAnyNumbers(params int[] numbers)
        {
            return GCD.Stein(numbers);
        }
    }
}
