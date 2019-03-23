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
        public static int InsertNumber(int inputNumber, int insertNumber, int i, int j)
        {
            BitArray inputNumberBits = new BitArray(new int[] { inputNumber });
            bool[] bits = new bool[inputNumberBits.Count];
            inputNumberBits.CopyTo(bits, 0);
            byte[] bitValues = bits.Select(bit => (byte)(bit ? 1 : 0)).ToArray();

            return 0;
        }
    }
}
