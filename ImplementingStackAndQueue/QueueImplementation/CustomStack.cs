using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackImplementation
{
    public class CustomStack<T>
    {
        private const int DefaultCapacity = 4;
        private T[] elements;
        public CustomStack()
        {
            elements = new T[DefaultCapacity];
        }

        public int Count { get; private set; }
        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }
        }
        public T Peek()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[Count - 1];
        }
        public T Pop()
        {
            if (elements.Length == 0)
            {
                throw new InvalidOperationException();
            }

            T lastElement = elements[Count - 1];

            Count--;

            return lastElement;
        }

        public void Push(T element)
        {
            Resize();
            elements[Count] = element;
            Count++;
        }

        private void Resize()
        {

            if (Count == elements.Length)
            {

                T[] newArray = new T[Count * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    newArray[i] = elements[i];
                }

                elements = newArray;
            }

        }
    }
}
