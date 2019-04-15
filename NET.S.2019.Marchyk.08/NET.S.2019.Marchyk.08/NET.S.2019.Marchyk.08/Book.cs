using System;

namespace Books
{
    /// <summary>
    /// Book essense
    /// </summary>
    public class Book : IComparable, IEquatable<Book>, IFormattable
    {
        /// <summary>
        /// Fields that contain information about book
        /// </summary>
        public string ISBN { get; }
        public string Author { get; }
        public string Name { get; }
        public string Publisher { get; }
        public int Year { get; }
        public int Pages { get; }
        public double Price { get; }

        /// <summary>
        /// Book constructor
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <param name="publisher"></param>
        /// <param name="year"></param>
        /// <param name="pages"></param>
        /// <param name="price"></param>
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

        /// <summary>
        /// Method for comparing books
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of compariong</returns>
        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }

            return string.Compare(book.Name, Name);
        }

        /// <summary>
        /// Mthod or comparing objects of any type with book
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Result of comparing</returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            var book = (Book)obj;

            return CompareTo(book);
        }

        /// <summary>
        /// Overrided Equals method for Book class
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Result of comparing</returns>
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

        /// <summary>
        /// Overrided GetHashCode method for Book class
        /// </summary>
        /// <returns>Hash of Book object</returns>
        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        /// <summary>
        /// Overrided ToString method for Book class
        /// </summary>
        /// <returns>String representation of Book object</returns>
        public override string ToString()
        {
            return ToString("5", null);
        }

        /// <summary>
        /// Method ToString from IFormattable interface
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatter"></param>
        /// <returns>Different formats of string representation of Book object</returns>
        public string ToString(string format, IFormatProvider formatter)
        {
            if (string.IsNullOrEmpty(format)) format = "5";

            switch (format)
            {
                case "1": return "Book: " + Name + ", Author: " + Author;
                case "2": return "Book: " + Name + ", Author: " + Author + " ISBN: " + ISBN;
                case "3": return "Book: " + Name + ", Author: " + Author + ", Year of publishing:. " + Year + ", " + Pages + " p." + ", ISBN: " + ISBN;
                case "4": return "Book: " + Name + ", Author: " + Author + ", Year of publishing:. " + Year + ", " + Pages + " p." + ", ISBN: " + ISBN + ", Publisher : " + Publisher;
                case "5": return "Book: " + Name + ", Author: " + Author + ", Year of publishing:. " + Year + ", " + Pages + " p." + ", ISBN: " + ISBN + ", Publisher : " + Publisher + "," + Price + " y.e ";
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }

            
        }

        /// <summary>
        /// Equals method for comparing Book objects
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of comparing</returns>
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
