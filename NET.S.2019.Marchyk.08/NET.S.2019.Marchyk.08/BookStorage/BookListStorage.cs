using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using System.IO;

namespace BookStorage
{
    public class BookListStorage
    {
        private readonly string Path;

        public BookListStorage(string path)
        {
            if (path == null || path.Length == 0)
            {
                throw new ArgumentException("Wrong object declaration");
            }

            Path = path;
        }

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

        public void AddBookToFile(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, book);
            }
        }

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
