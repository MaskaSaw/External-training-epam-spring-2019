using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using BookStorage;

namespace BookService
{
    /// <summary>
    /// Service for operations with Book objects
    /// </summary>
    public class BookListService
    {
        private readonly BookListStorage bookStorage;
        private List<Book> books = new List<Book>();

        /// <summary>
        /// BookListService constructor
        /// </summary>
        /// <param name="bookStorage"></param>
        public BookListService(BookListStorage bookStorage)
        {
            if (ReferenceEquals(bookStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookStorage = bookStorage;

        }

        /// <summary>
        /// Adds new Book object to list
        /// </summary>
        /// <param name="book"></param>
        public void AddBookToShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }

            books.Add(book);

        }

        /// <summary>
        /// Removes Book object from list
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBookFromShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Remove(book);
        }

        /// <summary>
        /// Finds Book object by given parameter
        /// </summary>
        /// <param name="param"></param>
        /// <returns>Book object that contains given parameter</returns>
        public Book FindBook(IFind param)
        {
            if (ReferenceEquals(param, null))
            {
                throw new ArgumentNullException();
            }
            return param.FindBookByTag();
        }

        /// <summary>
        /// Sorting of Book list
        /// </summary>
        /// <param name="comparator"></param>
        public void Sort(IComparer<Book> comparator)
        {
            var booksArray = books.ToArray();

            if (ReferenceEquals(comparator, null))
            {
                Array.Sort(booksArray);
            }
            else
            {
                Array.Sort(booksArray, comparator);
            }
            books.Clear();
            books.AddRange(booksArray);
        }

        /// <summary>
        /// Saves Book object to file
        /// </summary>
        public void Save()
        {
            bookStorage.SaveBooks(books);
        }

        /// <summary>
        /// Finds out all saved Book objects and represent them as a list of Book objects
        /// </summary>
        /// <returns>List of Book objects</returns>
        public List<Book> GetAllBooks()
        {
            return bookStorage.GetBooksList();
        }
    }
}
