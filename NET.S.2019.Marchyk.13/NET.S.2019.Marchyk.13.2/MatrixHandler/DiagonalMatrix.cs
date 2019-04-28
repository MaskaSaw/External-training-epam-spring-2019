using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandler
{
    class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] diagonalElements;

        public DiagonalMatrix(T[] DiagonalElements)
        {
            if (DiagonalElements == null)
                throw new ArgumentNullException(nameof(DiagonalElements));

            Size = DiagonalElements.Length;

            diagonalElements = DiagonalElements;
        }

        public override T GetValue(int i, int j)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Индекс не может быть меньше нуля");

            if (i > Size || j > Size)
                throw new ArgumentException("Индекс не может выходить за пределы матрицы");

            if (i != j)
                return default(T);

            return diagonalElements[i];
        }

        public override void SetValue(int i, int j, T value)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException("Индекс не может быть меньше нуля.");

            if (i > Size || j > Size)
                throw new ArgumentException("Индекс не может выходить за пределы матрицы");

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (i != j)
                throw new InvalidOperationException("Матрица содержит значения по умолчанию за пределами главной диагонали");

            diagonalElements[i] = value;

            OnChangeValue?.Invoke(i, j, value);
        }

        public override IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i != j)
                        yield return default(T);
                    else
                        yield return diagonalElements[i];
                }
            }
        }

        public event MethodSet OnChangeValue;
    }
}
