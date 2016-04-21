using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckParametrs;

namespace BookClass
{
    /// <summary>
    /// Class for describing book
    /// </summary>
    public class Book : Check, IEquatable<Book>, IComparable<Book>
    {
        #region Properties
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int Pages { get; private set; }
        public int Year { get; private set; }
        private static int nameId = 1;
        #endregion

        #region Constructors
        /// <summary>
        /// Create instance of Book
        /// </summary>
        /// <param name="name">Name of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="pages">Number of pages</param>
        /// <param name="year">Realeased</param>
        public Book(string author, string name, int pages, int year)
        {
            CheckRefOnNull(name);
            CheckRefOnNull(author);
            if (pages <= 0 || (year <= 700 && year > DateTime.Today.Year))
                throw new ArgumentException();
            Name = name;
            Author = author;
            Pages = pages;
            Year = year;
        }

        /// <summary>
        /// Create instance of Book
        /// </summary>
        /// <param name="name">Name of the Book(optional)</param>
        public Book(string name = "Unknown")
        {
            Name = name + nameId.ToString();
            nameId++;
            Author = string.Empty;
            Pages = 0;
            Year = 0;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Compare books by Name
        /// </summary>
        /// <param name="other">Book to compare</param>
        /// <returns>Int32</returns>
        public int CompareTo(Book other)
        {
            CheckRefOnNull(other);
            return Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Represent Book
        /// </summary>
        /// <returns>Name,Author,Year,Pages</returns>
        public override string ToString()
        {
            return $"Name: {Name} \r\nAuthor: {Author} \r\nYear: {Year.ToString()} \r\nPages: {Pages.ToString()}\r\n";
        }

        /// <summary>
        /// Compare books on equality
        /// </summary>
        /// <param name="other">Book</param>
        /// <returns>True if books are equal</returns>
        public bool Equals(Book other)
        {
            CheckRefOnNull(other);
            if (Name == other.Name && Author == other.Author && Pages == other.Pages && Year == other.Year)
                return true;
            return false;
        }

        /// <summary>
        /// Compare books on equality
        /// </summary>
        /// <param name="obj">Book</param>
        /// <returns>True if books are equal</returns>
        public override bool Equals(Object obj)
        {
            CheckRefOnNull(obj);
            CheckRefOnNull(this);

            Book book = obj as Book;
            if (book == null)
                return false;
            return Equals(book);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

        #region Operators

        public static bool operator ==(Book book1, Book book2)
        {
            CheckRefOnNull(book1);
            CheckRefOnNull(book2);
            return book1.Equals(book2);
        }

        public static bool operator !=(Book book1, Book book2)
        {
            return !book1.Equals(book2);
        }
        #endregion
    }
}
