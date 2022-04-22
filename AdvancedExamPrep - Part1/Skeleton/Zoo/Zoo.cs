using System.Collections.Generic;

namespace Zoo
{
    public class Zoo 
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public List<Animal> AnimalS { get; private set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
