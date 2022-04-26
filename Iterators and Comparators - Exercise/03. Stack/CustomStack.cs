using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class CustomStack<T> : IEnumerable<T>
    {
        public CustomStack()
        {
            Elements = new List<T>();
            Count = 0;
        }
        public List<T> Elements { get; set; }
        public int Count { get; set; }

        public void Pop()
        {
            if (Elements.Count == 0)
            {
                return;
            }
            int index = 0;
            if (Elements.Count > 1)
            {
                index = Elements.Count - 1;
            }

            Elements.RemoveAt(index);
            Count--;
        }

        public void Push(T element)
        {
            Count++;
            Elements.Add(element);
        }

        
        public IEnumerator<T> GetEnumerator()
        {

            for (int i = Elements.Count - 1; i >= 0; i--)
            {
                yield return Elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
