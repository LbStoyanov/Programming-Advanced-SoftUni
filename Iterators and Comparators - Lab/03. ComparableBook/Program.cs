using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {

            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }


            //Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            //Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            //Book bookThree = new Book("The Documents in the Case", 1930);
            //Book bookFourt = new Book("The EAlive in the Case", 1930);

            //List<Book> books = new List<Book>()
            //{
            //    bookOne, bookTwo, bookThree,bookFourt
            //};

            ////var sortedBooks = books.OrderBy(x => x.Year).ToList();
            //books.Sort();

            //foreach (var book in books)
            //{
            //    Console.WriteLine(book);
            //}
        }
    }
}
