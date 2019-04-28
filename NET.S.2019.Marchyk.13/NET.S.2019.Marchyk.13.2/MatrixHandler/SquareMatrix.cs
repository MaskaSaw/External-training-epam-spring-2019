using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandler
{
    class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[,] elements;

        /// <summary>
        /// First constructor for 1-dimentional array
        /// </summary>
        /// <param name="Elements"></param>
        public SquareMatrix(T[] Elements)
        {
            if (Elements == null)
                throw new ArgumentNullException(nameof(Elements));

            var sqrt = Math.Sqrt(Elements.Length);

            if (Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) > Double.Epsilon)
                throw new ArgumentException("Корень числа элементов должен быть int");

            Size = (int)Math.Sqrt(Elements.Length);

            elements = new T[Size, Size];

            for (int i = 0, h = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    elements[i, j] = Elements[h];
                    h++;
                }
            }
        }

        /// <summary>
        /// Constructor for 2-dimensional array
        /// </summary>
        /// <param name="array"></param>
        public SquareMatrix(T[][] Elements)
        {
            if (Elements == null)
                throw new ArgumentNullException(nameof(Elements));

            foreach (T[] row in Elements)
                if (row.Length != Elements.Length)
                    throw new ArgumentException("Введенный массив должен быть квадратным");

            Size = Elements.Length;

            elements = new T[Size, Size];

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    elements[i, j] = Elements[i][j];
        }

        public override T GetValue(int i, int j)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Индекс не может быть меньше нуля");

            if (i > Size || j > Size)
                throw new ArgumentException("Индекс не может выходить за пределы матрицы");

            return elements[i, j];
        }

        public override void SetValue(int i, int j, T value)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Индекс не может быть меньше нуля");

            if (i > Size || j > Size)
                throw new ArgumentException("Индекс не может выходить за пределы матрицы");

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            elements[i, j] = value;

            OnChangeValue(i, j, value);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    yield return elements[i, j];
        }

        public event MethodSet OnChangeValue;
    }
}
