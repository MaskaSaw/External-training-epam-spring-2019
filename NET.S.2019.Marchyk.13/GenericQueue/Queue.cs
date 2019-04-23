using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GenericQueue
{
    public class Queue<T>
    {
        #region Private fields
        private T[] elements;
        private int firstIndex;
        private int lastIndex;
        #endregion

        #region Public fields
        public int Count
        {
            get
            {
                return lastIndex - firstIndex + 1;
            }
        }
        #endregion

        #region Constructor
        public Queue(int numberOfElements = 10)
        {
            elements = new T[numberOfElements];
            firstIndex = 0;
            lastIndex = -1;
        }
        #endregion

        #region Operations

        public void Enqueue(T element)
        {
            if (lastIndex == elements.Length - 1)
            {
                T[] buf = new T[elements.Length];
                buf = elements;
                elements = new T[elements.Length * 2];

                for (int i = 0; i < buf.Length; i++)
                    elements[i] = buf[i];
            }

            lastIndex++;
            elements[lastIndex] = element;
        }

        public T Dequeue()
        {
            if (lastIndex > -1)
            {
                T result = elements[firstIndex];
                elements[firstIndex] = default(T);
                firstIndex++;
                return result;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty!");
            }              
        }

        public T GetElement()
        {
            if (lastIndex > -1)
            {
                return elements[firstIndex];
            }              
            else
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
        #endregion

        #region Iterator
        public T this[int index]
        {
            get
            {
                return elements[index];
            }
            set
            {
                elements[index] = value;
            }
        }

        public struct Iterator
        {
            private readonly Queue<T> collection;
            private int currentIndex;

            internal Iterator(Queue<T> _collection)
            {
                currentIndex = -1;
                collection = _collection;
            }

            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == collection.Count)
                        throw new InvalidOperationException();
                    return collection[currentIndex];
                }
            }

            public void Reset()
            {
                currentIndex = collection.firstIndex;
            }

            public bool MoveNext()
            {
                return ++currentIndex < collection.Count;
            } 
        }

        public Iterator GetEnumerator()
        {
            return new Iterator(this);
        }
        #endregion

        #region For testing
        public T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = firstIndex, j = 0; i <= lastIndex; i++, j++)
                array[j] = elements[i];

            return array;
        }
        #endregion
    }
}
