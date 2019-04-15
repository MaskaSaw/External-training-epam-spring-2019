using System.Collections.Generic;
using Books;
using System.Linq;

namespace BookService
{
    /// <summary>
    /// Class for finding Book object by its Name
    /// </summary>
    public class FindBookByName : IFind
    {
        public string Name { get; }
        public List<Book> Books { get; }
        public FindBookByName(string name, List<Book> books)
        {
            Name = name;
            Books = books;
        }

        public Book FindBookByTag()
        {
            return Books.FirstOrDefault(book => book.Name == Name);
        }
    }
}
