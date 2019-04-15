using System.Collections.Generic;
using Books;
using System.Linq;

namespace BookService
{
    /// <summary>
    /// Class for finding Book object by its ISBN
    /// </summary>
    class FindBookByISBN : IFind
    {
        public string ISBN { get; }
        public List<Book> Books { get; }

        public FindBookByISBN(string isbn, List<Book> books)
        {
            ISBN = isbn;
            Books = books.ToList();
        }
      
        public Book FindBookByTag()
        {
            return Books.FirstOrDefault(book => book.ISBN == ISBN);
        }
    }
}
