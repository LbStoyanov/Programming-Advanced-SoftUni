using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;
        public Library()
        {
            this.books = new List<Book>();
        }
        public Library(Book bookOne,Book bookTwo,Book bookThree)
        {
            this.books = new List<Book>() { bookOne,bookTwo,bookThree};
        }

        //public void Add(Book book)
        //{
        //   this.books.Add(book);
        //}

        //public void Remove(Book book)
        //{
        //    this.books.Remove(book);
        //}
        public IEnumerator<Book> GetEnumerator()
        {
           return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
