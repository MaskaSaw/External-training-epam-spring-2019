using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinarySearchTree;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var intTree = new BinarySearchTree<int>() { 7, 5, 4, 6, 1, 9, 8, 10 };

            foreach (var node in intTree.Preorder())
            {
                Console.WriteLine(node);
            }

            Console.WriteLine();

            var stringTree = new BinarySearchTree<string> { "1", "2", "3", "4" };

            foreach (var node in stringTree.Inorder())
            {
                Console.WriteLine(node);
            }

            Console.ReadLine();
        }

    }
}
