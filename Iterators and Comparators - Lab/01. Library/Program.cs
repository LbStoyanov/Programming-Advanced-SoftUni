using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("The call",1999,"J.K. Bako");
            
            

            Library library = new Library();
            library.Add(book);
            library.Add(book);
            library.Add(book);
            library.Add(book);
            library.Add(book);

            foreach (var item in library)
            {
                Console.WriteLine(String.Join(", ",item.Authors));
            }

        }
    }
}
