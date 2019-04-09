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
    public class BookListService
    {
        private readonly BookListStorage bookStorage;
        private List<Book> books = new List<Book>();


        public BookListService(BookListStorage bookStorage)
        {
            if (ReferenceEquals(bookStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookStorage = bookStorage;

        }

        public void AddBookToShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }

            books.Add(book);

        }

        public void RemoveBookFromShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Remove(book);
        }

        public Book FindBook(IFind param)
        {
            if (ReferenceEquals(param, null))
            {
                throw new ArgumentNullException();
            }
            return param.FindBookByTag();
        }

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

        public void Save()
        {
            bookStorage.SaveBooks(books);
        }

        public List<Book> GetAllBooks()
        {
            return bookStorage.GetBooksList();
        }
    }
}
