using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using System.IO;

namespace BookStorage
{
    /// <summary>
    /// Class for saving and loading Book objects from binary file
    /// </summary>
    public class BookListStorage
    {
        private readonly string Path;

        /// <summary>
        /// BookListStorage constructor
        /// </summary>
        /// <param name="path"></param>
        public BookListStorage(string path)
        {
            if (path == null || path.Length == 0)
            {
                throw new ArgumentException("Wrong object declaration");
            }

            Path = path;
        }

        /// <summary>
        /// Loads all Book objects from binary file to list
        /// </summary>
        /// <returns>List of Book objects</returns>
        public List<Book> GetBooksList()
        {
            List<Book> books = new List<Book>();
            using(var br = new BinaryReader(File.Open(Path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var isbn = br.ReadString();
                    var author = br.ReadString();
                    var name = br.ReadString();
                    var publisher = br.ReadString();
                    var year = br.ReadInt32();
                    var pages = br.ReadInt32();
                    var price = br.ReadDouble();
                    Book book = new Book(isbn, author, name, publisher, year, pages, price);
                    books.Add(book);
                }
            }

            return books;
        }

        /// <summary>
        /// Saves Book object to binary file
        /// </summary>
        /// <param name="book"></param>
        public void AddBookToFile(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, book);
            }
        }

        /// <summary>
        /// Saves list of Book objects to binary file
        /// </summary>
        /// <param name="books"></param>
        public void SaveBooks(List<Book> books)
        {

            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in books)
                {
                    Writer(bw, book);
                }
            }
        }

        /// <summary>
        /// Incapsulated logic of saving Book object to file
        /// </summary>
        /// <param name="bw"></param>
        /// <param name="book"></param>
        public static void Writer(BinaryWriter bw, Book book)
        {
            bw.Write(book.ISBN);
            bw.Write(book.Author);
            bw.Write(book.Name);
            bw.Write(book.Publisher);
            bw.Write(book.Year);
            bw.Write(book.Pages);
            bw.Write(book.Price);
        }
    }   
}
