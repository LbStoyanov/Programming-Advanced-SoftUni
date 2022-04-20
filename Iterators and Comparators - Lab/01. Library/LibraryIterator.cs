using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class LibraryIterator : IEnumerator<Book>
    {
        private  List<Book> books;
        private int index;

        public LibraryIterator(List<Book> books)
        {
            this.books = books;
            this.index = -1;
        }
        public Book Current => books[index];

        object IEnumerator.Current => Current;

       
        public bool MoveNext()
        {
            index++;
            if (index < books.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            index = -1;
        }
        public void Dispose()
        {
        }

    }
}
