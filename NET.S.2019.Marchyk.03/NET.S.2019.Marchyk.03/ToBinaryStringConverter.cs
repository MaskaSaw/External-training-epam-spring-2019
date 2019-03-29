using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class ToBinaryStringConverter
    {
        private const int ExponentLength = 11;
        private const int MantissaLength = 52;
        private const int ExponentOffset = 1023;
        private const int SubnormalExponentOffset = -1022;

        /// <summary>
        /// Returns <paramref name="num"/>'s binary representation as it is stored in memory.
        /// </summary>
        /// <param name="num">A <see cref="double"/> number.</param>
        /// <returns><paramref name="num"/>'s binary representation.</returns>
        public static string ConvertToBinaryString(this double num)
        {
            string sign;

            ////Sign
            if (IsNegative(num))
            {
                sign = "1";
                num = Math.Abs(num);
            }
            else
            {
                sign = "0";
            }

            ////Exponent
            int exponent = GetExponent(num);
            string exponentStr = ConvertExponentToStr(exponent);

            ////Mantissa
            double mantissa = GetMantiss(num, exponent);
            string mantissaStr = ConverMantissToString(mantissa);

            return $"{sign}{exponentStr}{mantissaStr}";
        }

        private static bool IsNegative(double num)
        {
            return double.IsNaN(num) || num < 0 || (num == 0.0 && double.IsNegativeInfinity(1.0 / num));
        }

        private static int GetExponent(double num)
        {
            if (double.IsNaN(num))
            {
                return (int)(Math.Pow(2, ExponentLength) - 1);
            }

            int power = 0;

            double fraction = num - 1;

            while (fraction < 0 || fraction >= 1)
            {
                if (fraction < +0.0)
                {
                    --power;
                }
                else
                {
                    ++power;
                }

                fraction = (num / Math.Pow(2, power)) - 1;
            }

            power += ExponentOffset;

            power = (power < 0) ? 0 : power;

            return power;
        }

        private static string ConvertExponentToStr(int exponent)
        {
            var result = new StringBuilder();
            for (int i = 0; i < ExponentLength; i++)
            {
                result.Insert(0, exponent % 2);
                exponent /= 2;
            }

            return result.ToString();
        }

        private static double GetMantiss(double num, int exponent)
        {
            if (double.IsNegativeInfinity(num) || double.IsPositiveInfinity(num))
            {
                return 0;
            }

            if (double.IsNaN(num))
            {
                return 0.1;
            }

            double fractional;

            exponent -= ExponentOffset;

            if (exponent <= -ExponentOffset)
            {
                fractional = num / Math.Pow(2, SubnormalExponentOffset);
            }
            else
            {
                fractional = (num / Math.Pow(2, exponent)) - 1;
            }

            return fractional;
        }

        private static string ConverMantissToString(double mantissa)
        {
            var result = new StringBuilder();

            for (int i = 0; i < MantissaLength; i++)
            {
                mantissa *= 2;
                int intPart = (int)mantissa;
                result.Append(intPart.ToString());
                mantissa -= intPart;
            }

            return result.ToString();
        }
    }
}
