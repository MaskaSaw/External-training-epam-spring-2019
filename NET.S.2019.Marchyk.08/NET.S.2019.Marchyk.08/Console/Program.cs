using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using BookService;
using BookStorage;
using Logs;

namespace ConsoleProgram

{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BookListStorage bookStorage = new BookListStorage("NewStorage.bin");
                BookListService bookService = new BookListService(bookStorage);

                bookService.AddBookToShop(new Book("978-3-16-123451-0", "Ivanov", "one", "Minsk", 2000, 1000, 100));
                bookService.AddBookToShop(new Book("978-3-16-123452-1", "Petrov", "two", "Gomel", 2001, 2000, 200));
                bookService.AddBookToShop(new Book("978-3-16-123453-2", "Glebov", "three", "Brest", 2002, 3000, 300));
                bookService.AddBookToShop(new Book("978-3-16-123454-3", "Arkhipov", "four", "Vitebsk", 2003, 4000, 400));

                var books = new List<Book>();
                books.Add(bookService.FindBook(new FindBookByName("one", bookService.GetAllBooks())));
                PrintBook(books);

                bookService.Sort(null);
                PrintBook(bookService.GetAllBooks());

                Console.WriteLine(books[0].ToString("2", CultureInfo.CurrentCulture));
                bookService.Save();
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Log.Write(ex);
            }
            
        }

        public static void PrintBook(List<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book);
            Console.WriteLine();
        }

        public static void PrintBook(Book book)
        {
            Console.WriteLine(book);
        }
    }
}
