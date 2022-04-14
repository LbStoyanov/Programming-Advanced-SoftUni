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
        public int RemoveAt(int index)
        {
            int number = elements[index];

            elements[index] = 0;

            for (int i = 0; i < counter; i++)
            {
                elements[i] = elements[i + 1];
            }

            return number;
        }

        public void Add(int element)
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
    }
}