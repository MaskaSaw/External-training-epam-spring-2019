using System;
using URLDataParser;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            URLParser parser = new URLParser();
            parser.ExportDataFromFile(System.IO.Directory.GetCurrentDirectory() + "Test.txt");

            Console.WriteLine("Data was serialized");
            Console.ReadLine();
        }
    }
}
