using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryFileBookRepository;
using BookClass;
using WorkWithBooks;

namespace BookServiceConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BookService service = new BookService(new BinaryFileRepository("Book.doc"));


            Book book1 = new Book("Lewis Carroll", "Alice in Wonderland", 890, 1865);
            Book book2 = new Book("Patrick Süskind", "Perfume: The Story of a Murderer", 1029, 1985);
            Book book3 = new Book("Leo Tolstoy", "War and Peace", 1225, 1869);

            service.AddBook(book1);
            service.AddBook(book2);
            service.AddBook(book3);

            foreach (var x in service.Books)
            {
                Console.WriteLine(x.ToString());
            }

            service.SortBooks(new CompareByName());

            foreach (var x in service.Books)
            {
                Console.WriteLine(x.ToString());
            }

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine(service.FindByTag((a) => a.Author.Contains("Leo Tolstoy")).ToString());
            Console.WriteLine(service.FindByName("Alice in Wonderland"));
            
            Console.Read();
        }
    }
}
