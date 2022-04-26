using System.Collections.Generic;
using System.Linq;

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
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsByDiet = new List<Animal>();

            foreach (var animal in Animals.Where(x => x.Diet == diet))
            {
                animalsByDiet.Add(animal);
            }
            
            return animalsByDiet;
        }
        public int RemoveAnimals(string species)
        {
            int removedAnimalsCount = 0;

            foreach (Animal animal in Animals.Where(x => x.Species == species))
            {
                Animals.Remove(animal);
                removedAnimalsCount++;
            }

            return removedAnimalsCount;
        }
        public string AddAnimal(Animal animal)
        {
            if (Capacity == 0)
            {
                return "The zoo is full.";
            }

            Capacity--;

            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" || animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
    }
}
