using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            if (this.Year > other.Year)
            {
                return 1;
            }
            else if (this.Year < other.Year)
            {
                return -1;
            }
            else
            {
                return this.Title.CompareTo(other.Title);

                //if (this.Title.CompareTo(other.Title) > 0)
                //{
                //    return 1;
                //}
                //else if (this.Title.CompareTo(other.Title) < 0)
                //{
                //    return -1;
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}"; 
        }
    }
}
