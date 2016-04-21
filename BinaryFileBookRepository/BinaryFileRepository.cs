using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRepositoryInterface;
using BookClass;
using CheckParametrs;

namespace BinaryFileBookRepository
{
    /// <summary>
    /// Create Binary file repository for book
    /// </summary>
    public class BinaryFileRepository : Check, IBookRepository
    {
        #region Fields
        public static string FileName { get; private set; }
        #endregion

        #region Constructor
        public BinaryFileRepository(string fileName)
        {
            CheckRefOnNull(fileName);
            FileName = fileName;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Load books from binary file
        /// </summary>
        /// <returns>Collection of books</returns>
        public IEnumerable<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(FileName, FileMode.OpenOrCreate)))
                {
                    while (reader.PeekChar() != -1)
                    {
                        string author = reader.ReadString();
                        string name = reader.ReadString();
                        int year = reader.ReadInt32();
                        int pages = reader.ReadInt32();
                        books.Add(new Book(name, author, pages, year));
                    }
                    return books;
                }
            }
            catch
            {
                throw new IOException();
            }

        }

        /// <summary>
        /// Save books in binary file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void SaveBooks(IEnumerable<Book> books)
        {
            CheckRefOnNull(books);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(FileName, FileMode.OpenOrCreate)))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.Name);
                        writer.Write(book.Author);
                        writer.Write(book.Year);
                        writer.Write(book.Pages);
                    }
                }
            }
            catch
            {
                throw new IOException();
            }
        }
        #endregion
    }
}
