using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;
using BinaryFileBookRepository;
using BookRepositoryInterface;
using CheckParametrs;

namespace WorkWithBooks
{
    public class BookService : Check
    {
        #region Fields
        private readonly IBookRepository repository;
        #endregion

        #region Properties
        public List<Book> Books { get; private set; }
        #endregion

        #region Constructors
        public BookService(IBookRepository repository)
        {
            CheckRefOnNull(repository);
            this.repository = repository;
            Books = repository.LoadBooks().ToList<Book>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Add collection of books to the file
        /// </summary>
        /// <param name="books">Collection of books</param>
        public void AddBook(IEnumerable<Book> books)
        {
            CheckRefOnNull(books);
            foreach (var book in books)
            {
                AddBook(book);
            }
        }
        /// <summary>
        /// Add book to the file
        /// </summary>
        /// <param name="book">Book</param>
        public void AddBook(Book book)
        {
            CheckRefOnNull(book);
            try
            {
                if (this.Books.Contains<Book>(book))
                    throw new ArgumentException();
                Books.Add(book);
                repository.SaveBooks(this.Books);
            }
            catch (ArgumentException e)
            {
                //logger.Log(e);
            }
        }

        /// <summary>
        /// Remove book from the file
        /// </summary>
        /// <param name="book">Book</param>
        public void RemoveBook(Book book)
        {
            CheckRefOnNull(book);
            Books.Remove(book);
            repository.SaveBooks(this.Books);
        }

        /// <summary>
        /// Sort books in file
        /// </summary>
        /// <param name="comparer">IComparer</param>
        public void SortBooks(IComparer<Book> comparer)
        {
            CheckRefOnNull(comparer);
            SortBooks(comparer.Compare);
            repository.SaveBooks(Books);
        }
        /// <summary>
        /// Sort books in the file
        /// </summary>
        /// <param name="comparer">Comparision</param>
        public void SortBooks(Comparison<Book> comparer)
        {
            CheckRefOnNull(comparer);
            Books.Sort(comparer);
            repository.SaveBooks(Books);
        }

        /// <summary>
        /// Find book by tag
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>Book</returns>
        public Book FindByTag(Predicate<Book> predicate)
        {
            try
            {
                return Books.Find(predicate);
            }
            catch (ArgumentNullException e)
            {
                //logger.Fatal("predicate is null. " + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Search book by name
        /// </summary>
        /// <param name="name">Name of the book</param>
        /// <returns>Book with Name</returns>
        public Book FindByName(string name)
        {
            try
            {
                return FindByTag(book => book.Name == name);
            }
            catch (ArgumentNullException e)
            {
                //logger.Fatal("predicate is null. " + e.Message);
                throw;
            }
        }
        /// <summary>
        /// Search book by author
        /// </summary>
        /// <param name="author">Author of the book</param>
        /// <returns>Book with Author</returns>
        public Book FindByAuthor(string author)
        {
            try
            {
                return FindByTag(book => book.Author == author);
            }
            catch (ArgumentNullException e)
            {
                //logger.Fatal("predicate is null. " + e.Message);
                throw;
            }
        }
        #endregion
    }
}
