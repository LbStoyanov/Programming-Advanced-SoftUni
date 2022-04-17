using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> internalList = new List<T>();
        
        public void  Add(T element)
        {
           this.internalList.Add(element);
        }
        public T Remove()
        {
            T elementForRemove = this.internalList.Last();

            this.internalList.Remove(elementForRemove);

            return elementForRemove;
        }
        public int Count()
        {
            return internalList.Count;
        }
    }
}