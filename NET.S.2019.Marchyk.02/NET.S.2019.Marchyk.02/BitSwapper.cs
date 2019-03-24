using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Marchyk._02
{
    public class BitSwapper
    {
        /// <summary>
        /// InsertNumber is the method which translate both integer numbers into binary form and then
        /// insert the first one into another one.
        /// </summary>
        /// <param name="inputNumber">Number which service such as platform for insertion</param>
        /// <param name="insertNumber">Number which you want to insert into 'targetNumber'</param>
        /// <param name="i">Start index of insertion</param>
        /// <param name="j">End index of insertion</param>
        /// <returns>Integer number - result of insertion.</returns>
        public static int InsertNumber(int inputNumber, int insertNumber, int i, int j)
        {
            if ((i < 0 || j < 0) || (i > 31 || j > 31))
                throw new ArgumentException("Indexes can't be negative or more then 31.");

            if ((j - i + Convert.ToString(inputNumber, 2).Length) > 31)
                throw new ArgumentException("Insertion range is too big");

            if (i > j)
                throw new ArgumentException("Index i must be less or equal j.");

            if (Convert.ToString(inputNumber, 2).Length + Convert.ToString(insertNumber, 2).Length > 31)
                throw new ArgumentException("InputNumber is too big");           

            BitArray inputNumberBits = new BitArray(new int[] { inputNumber });
            BitArray insertNumberBits = new BitArray(new int[] { insertNumber });
            bool[] bits = new bool[inputNumberBits.Count];
            inputNumberBits.CopyTo(bits, 0);
            byte[] inputBitValues = bits.Select(bit => (byte)(bit ? 1 : 0)).ToArray();
            insertNumberBits.CopyTo(bits, 0);
            byte[] insertBitValues = bits.Select(bit => (byte)(bit ? 1 : 0)).ToArray();

            inputBitValues.Reverse();
            insertBitValues.Reverse();

            int pos = 0;
            do
            {
                inputBitValues[i] = insertBitValues[pos];
                i++;
                pos++;
            }
            while (i < j);

            inputBitValues.Reverse();
            string str = "";
            for (int n = 0; n < inputBitValues.Length; n++)
                str += inputBitValues[n].ToString();

            str = new string(str.ToCharArray().Reverse().ToArray());
            int result = Convert.ToInt32(str, 2);
            
            return result;
        }
    }
}
