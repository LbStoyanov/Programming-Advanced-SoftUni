using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public List<T> SwapElements(List<T> items, int firstIndex,int secondIndex)
        {
            T firstElement = items[firstIndex]; //Peter
            T secomdElement = items[secondIndex];//Swap me with Peter
            var temp = firstElement; 
            

            items[firstIndex] = secomdElement;
            items[secondIndex] = temp;

            Items = items;

            return items;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();


            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }
    }
}
