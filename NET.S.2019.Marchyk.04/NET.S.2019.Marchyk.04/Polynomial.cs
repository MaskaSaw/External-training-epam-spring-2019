using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynom

{
    /// <summary>
    /// Class for creation and making overrided operations with polynom
    /// </summary>
    public sealed class Polynomial
    {
  
        public double[] Index { get; private set; }
        /// <summary>
        /// Constructor of Polynomial class
        /// </summary>
        /// <param name="index">An array of indexes</param>
        public Polynomial(double[] id)
        {
            Index = id;
        }

        /// <summary>
        /// Order property
        /// </summary>
        public int Order
        {
            get
            {
                for (int i = Index.Length - 1; i >= 0; i--)
                    if (Math.Abs(Index[i]) > double.Epsilon)
                        return i;
                return 0;
            }
        }

        
        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="factor"></param>
        /// <returns></returns>
        public double this[int factor]
        {
            get
            {
                if (factor < 0) throw new ArgumentOutOfRangeException();
                if (factor >= Index.Length) return 0;
                return Index[factor];
            }
        }


        /// <summary>
        /// Converts polynomial to string form
        /// </summary>
        /// <returns>String representation of given polynomial</returns>
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < Index.Length; i++)
            {
                if(Math.Abs(Index[i]) > double.Epsilon)
                {
                    if (i == 0)
                    {
                        str.AppendFormat("{0}", Index[i]);
                        continue;
                    }
           
                    if (Index[i] > 0 && str.Length > 0)
                        str.AppendFormat(" + {0}*x^{1}", Index[i], i);
                    else
                        str.AppendFormat(" {0}*x^{1}", Index[i], i);
                }           
            }

            return str.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            Polynomial p = obj as Polynomial;

            if (p.Order != Order)
                return false;

            for (int i = 0; i <= this.Order; i++)
            {
                if (Math.Abs(this[i] - p[i]) > double.Epsilon)
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 1;
            foreach (var factor in Index)
            {
                hashCode *= (int)factor;
                hashCode += Order;
            }

            return hashCode;
        }

        /// <summary>
        /// Overloaded polynomial operation +
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>Sum result</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int minLength = 1;
            int maxLength = 1;

            if (first.Order > second.Order)
                maxLength += first.Order;
            else
                maxLength += second.Order;

            if (first.Order < second.Order)
                minLength += first.Order;
            else
                minLength += second.Order;
                      
            double[] Factors = new double[maxLength];
            for (int i = 0; i < minLength; i++)
                Factors[i] = first[i] + second[i];

            if (first.Order > second.Order)
                Array.Copy(first.Index, minLength, Factors, minLength, maxLength - minLength);
            else
                Array.Copy(second.Index, minLength, Factors, minLength, maxLength - minLength);

            return new Polynomial(Factors);
        }

        /// <summary>
        /// Overloaded polynomial operation -
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>Substruct result</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            int minLength = 1;
            int maxLength = 1;

            if (first.Order > second.Order)
                maxLength += first.Order;
            else
                maxLength += second.Order;

            if (first.Order < second.Order)
                minLength += first.Order;
            else
                minLength += second.Order;

            double[] Factors = new double[maxLength];
            for (int i = 0; i < minLength; i++)
                Factors[i] = first[i] - second[i];

            if (first.Order > second.Order)
                Array.Copy(first.Index, minLength, Factors, minLength, maxLength - minLength);
            else
                for (int i = minLength; i < maxLength; i++)
                    Factors[i] = -second[i];

            return new Polynomial(Factors);
        }

        /// <summary>
        /// All overloaded variants of polynomial operation *
        /// </summary>
        /// <param name="polynomial">Polynomial</param>
        /// <param name="multiplier">multiplier or another polynomial</param>
        /// <returns>Multiplication result</returns>
        public static Polynomial operator *(Polynomial polynomial, int multiplier)
        {
            double[] Factors = new double[polynomial.Order + 1];
            for (int i = 0; i < polynomial.Order + 1; i++)
                Factors[i] = polynomial[i] * multiplier;
            return new Polynomial(Factors);
        }

        public static Polynomial operator *(Polynomial polynomial, double multiplier)
        {
            double[] Factors = new double[polynomial.Order + 1];
            for (int i = 0; i < polynomial.Order + 1; i++)
                Factors[i] = polynomial[i] * multiplier;
            return new Polynomial(Factors);
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int resultOrder = first.Order + second.Order + 1;
            double[] resultForces = new double[resultOrder];

            for (int i = 0; i <= first.Order; i++)
            {
                if (Math.Abs(first[i]) > double.Epsilon)
                {
                    for (int j = 0; j <= second.Order; j++)
                        resultForces[i + j] += first[i] * second[j];
                }
            }

            return new Polynomial(resultForces);
        }

        /// <summary>
        /// Overloaded polynomial operation /
        /// </summary>
        /// <param name="polynomial">Polynomial</param>
        /// <param name="multiplier">Multiplier</param>
        /// <returns>Division result</returns>
        public static Polynomial operator /(Polynomial polynomial, int multiplier)
        {
            double[] Factors = new double[polynomial.Order + 1];
            for (int i = 0; i < polynomial.Order + 1; i++)
                Factors[i] = polynomial[i] / multiplier;
            return new Polynomial(Factors);
        }

        /// <summary>
        /// Reversed overloaded polynomial operation * for int multiplier
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static Polynomial operator *(int multiplier, Polynomial polynomial)
        {
            return polynomial * multiplier;
        }

        /// <summary>
        /// Reversed overloaded polynomial operation * for double multiplier
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="polynomial"></param>
        /// <returns></returns>
        public static Polynomial operator *(double multiplier, Polynomial polynomial)
        {
            return polynomial * multiplier;
        }

        /// <summary>
        /// Overloadede polynomial operation ==
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>Result of comparing</returns>

        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first.Index.Length != second.Index.Length)
            {
                return false;
            }
            for (int i = 0; i < first.Index.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Overloadede polynomial operation !=
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>Result of comparing</returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }
    }
}
