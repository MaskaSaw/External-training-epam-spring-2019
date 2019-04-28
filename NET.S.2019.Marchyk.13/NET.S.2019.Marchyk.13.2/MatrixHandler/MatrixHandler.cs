using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHandler
{
    class MatrixHandler
    {
        public void Message<T>(int i, int j, T value)
        {
            Console.WriteLine($"Значение элемента [{i}][{j}] изменилось. Новое значение: {value}.");
        }
    }
}
