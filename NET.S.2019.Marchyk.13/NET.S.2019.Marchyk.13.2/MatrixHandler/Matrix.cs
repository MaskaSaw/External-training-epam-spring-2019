using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandler
{
    public abstract class Matrix<T> : IEnumerable<T>, IEquatable<Matrix<T>>
    {
        protected int _size;

        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Size of matrix can't be less or equal to zero.");

                _size = value;
            }
        }

        public bool Equals(Matrix<T> other)
        {
            if (other == null)
                return false;

            if (this.Size != other.Size)
                return false;

            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    if (!this.GetValue(i, j).Equals(other.GetValue(i, j)))
                        return false;

            return true;
        }

        public abstract T GetValue(int i, int j);

        public abstract void SetValue(int i, int j, T value);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override bool Equals(object obj)
        {
            return Equals(obj as Matrix<T>);
        }

        public delegate void MethodSet(int i, int j, T value);

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
