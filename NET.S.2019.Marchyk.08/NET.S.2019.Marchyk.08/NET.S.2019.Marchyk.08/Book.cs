using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Book : IComparable, IEquatable<Book>
    {
        public string ISBN { get; }
        public string Author { get; }
        public string Name { get; }
        public string Publisher { get; }
        public int Year { get; }
        public int Pages { get; }
        public double Price { get; }

        public Book(string isbn, string author, string name, string publisher, int year, int pages, double price)
        {
            ISBN = isbn;
            Author = author;
            Name = name;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }

            return string.Compare(book.Name, Name);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            var book = (Book)obj;

            return CompareTo(book);
        }

        public override bool Equals(object obj)
        {
            var book = (Book)obj;
            if (book == null)
                return false;
            if (ISBN == book.ISBN && Author == book.Author && Name == book.Name && Publisher == book.Publisher && Year == book.Year && Pages == book.Pages)
            {
                return true;
            }

            return false;  
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        public override string ToString()
        {
            return "Book: " + Name + ", Author: " + Author + ", Year of publishing:. " + Year + ", " + Pages + " p." + ", ISBN: " + ISBN + ", Publisher : " + Publisher + "," + Price + " y.e ";
        }

        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return false;
            }
            if (ReferenceEquals(this, book))
            {
                return true;
            }
            return book.ISBN == ISBN;
        }
    }
}
