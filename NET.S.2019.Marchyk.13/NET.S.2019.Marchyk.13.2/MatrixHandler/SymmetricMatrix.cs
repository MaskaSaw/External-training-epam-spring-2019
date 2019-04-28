using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandler
{
    class SymmetricMatrix<T> : Matrix<T>
    {
        private readonly T[][] elements;

        public SymmetricMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
                if (array[i].Length != array.Length)
                    throw new ArgumentException("Введенный массив должен быть квадратным");

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length; j++)
                    if (!array[i][j].Equals(array[j][i]))
                        throw new ArgumentException("В массиве не содержатся симметричные относительно главной диагонали элементы");

            Size = array.Length;

            elements = new T[Size][];

            for (int i = 1; i <= Size; i++)
                elements[i - 1] = new T[i];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < elements[i].Length; j++)
                    elements[i][j] = array[i][j];
        }

        public override T GetValue(int i, int j)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Index of element can't be less then zero.");

            if (i > Size || j > Size)
                throw new ArgumentException("Index of element can't be greater then size of matrix.");

            if (j > i)
                return elements[j][i];

            return elements[i][j];
        }

        public override void SetValue(int i, int j, T value)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Index of element can't be less then zero.");

            if (i > Size || j > Size)
                throw new ArgumentException("Index of element can't be greater then size of matrix.");

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (i != j)
                throw new ArgumentException("You can't change non-diagonal element of matrix. You need to change both symmetric values.");

            elements[i][j] = value;

            OnChangeValue?.Invoke(i, j, value);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j > i)
                        yield return elements[j][i];
                    else
                        yield return elements[i][j];
                }
            }
        }

        public event MethodSet OnChangeValue;
    }
}
