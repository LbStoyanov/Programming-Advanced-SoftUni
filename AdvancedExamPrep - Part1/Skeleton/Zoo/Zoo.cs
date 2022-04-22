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
        public List<Animal> Animals { get; private set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" || animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (true)
            {

            }

            return $"Successfully added {animal.Species} to the zoo.";
        }
    }
}
