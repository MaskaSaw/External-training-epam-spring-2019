using System;
using NUnit.Framework;

namespace Polynom
{
    [TestFixture]
    public class PolynomialTest
    {
        [TestCase(new double[] { 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        public static int OrderProperty_PositiveTest(double[] array)
        {
            Polynomial p = new Polynomial(array);
            return p.Order;
        }

        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 3, ExpectedResult = 7)]
        [TestCase(new double[] { 1, 4, 3, 7, 5 }, 4, ExpectedResult = 5)]
        public static double CoeffProperty_PositiveTest(double[] array, int factor)
        {
            Polynomial p = new Polynomial(array);
            return p[factor];
        }

        [TestCase(new double[] { 1, 4, 3 }, new double[] {1, 4})]
        public static void PlusOperation_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p = p1 + p2;

            double[] expected = new double[p2.Order > p1.Order ? p2.Order + 1 : p1.Order + 1];
            if (array1.Length > array2.Length)
            {
                for (int i = 0; i < array2.Length; i++)
                    expected[i] = array1[i] + array2[i];
                for (int i = array2.Length; i < array1.Length; i++)
                    expected[i] = array1[i];
            }
            else
            {
                for (int i = 0; i < array1.Length; i++)
                    expected[i] = array1[i] + array2[i];
                for (int i = array1.Length; i < array2.Length; i++)
                    expected[i] = array2[i];
            }
           
            CollectionAssert.AreEqual(expected, p.Index);
        }

        [TestCase(new double[] { 1, 4, 3 }, new double[] { 0, 0, 0, 1, 4, 3 })]
        public static void MinusOperation_PositiveTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            Polynomial p = p1 - p2;

            double[] expected = new double[p2.Order > p1.Order ? p2.Order + 1 : p1.Order + 1];
            if (array1.Length > array2.Length)
            {
                for (int i = 0; i < array2.Length; i++)
                    expected[i] = array1[i] - array2[i];
                for (int i = array2.Length; i < array1.Length; i++)
                    expected[i] = array1[i];
            }
            else
            {
                for (int i = 0; i < array1.Length; i++)
                    expected[i] = array1[i] - array2[i];
                for (int i = array1.Length; i < array2.Length; i++)
                    expected[i] = -array2[i];
            }

            CollectionAssert.AreEqual(expected, p.Index);
        }

        [TestCase(new double[] { 1, 4 }, new double[] { 1, 8, 16 })]
        public static void MultiplyByPolynomialOperation_PositiveTest(double[] array, double[] expected)
        {
            Polynomial p = new Polynomial(array);
            p = p * p;

            CollectionAssert.AreEqual(expected, p.Index);
        }

        [TestCase(new double[] { 1, 2 }, ExpectedResult = "1 + 2*x^1")]
        [TestCase(new double[] { 0, 1, 2, 10 }, ExpectedResult = "1*x^1 + 2*x^2 + 10*x^3")]
        public static string ToString_PositiveTest(double[] array)
        {
            Polynomial p = new Polynomial(array);
            return p.ToString();
        }
    }
}
