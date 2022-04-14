using System;

namespace ImplementingStackAndQueue
{
    public class CustomList
    {
        private int[] elements;
        private int counter;
        public CustomList()
        {
            elements = new int[2];
            counter = 0;
        }
        public int Count 
        {
            get { return counter; }
        }

        public int this[int i] 
        {
            get
            {
                EnsureIsInRange(i);

                return elements[i];

            }

            set 
            {
                EnsureIsInRange(i);

                elements[i] = value; 
            }
        }

       

        public void Swap(int firstIndex, int secondIndex)
        {
            int firstElement = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = firstElement;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < counter; i++)
            {
                if (elements[i] == element)
                {
                    return true;
                }
            }

            return false;
        }
        public int RemoveAt(int index)
        {
            EnsureIsInRange(index);

            int number = elements[index];
            counter--;

            for (int i = index; i < counter; i++)
            {
                elements[i] = elements[i + 1];
            }

            return number;
        }
        public void Add(int element)
        {
            Resize();
            elements[counter] = element;
            counter++;
        }

        public void Shrink()
        {
            int[] newArray = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                newArray[i] = elements[i];
            }

            elements = newArray;
        }
        private void Resize()
        {
            if (elements.Length == counter)
            {
                int[] copyArray = new int[elements.Length * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    copyArray[i] = elements[i];
                }

                elements = copyArray;
            }
        }
        private void EnsureIsInRange(int i)
        {
            if (i < 0 && i >= counter)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}