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
            Animals = new List<Animal>();
        }
        public List<Animal> Animals { get; set; }
        

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.FindAll(x => x.Lenght >= minimumLength && x.Lenght <= maximumLength).Count;

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
        public Animal GetAnimalByWeight(double weight)
        {
            if (Capacity > 0)
            {
                return Animals.FirstOrDefault(a => a.Weight == weight);
            }

            return null;
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsByDiet = new List<Animal>();

            foreach (var animal in Animals.Where(x => x.Diet == diet))
            {
                animalsByDiet.Add(animal);
            }

            return animalsByDiet;
            //return Animals.Where(a => a.Diet == diet).ToList();
        }
        public int RemoveAnimals(string species)
        {
            int removedAnimalsCount = Animals.FindAll(x => x.Species == species).Count;

            //foreach (Animal animal in Animals.Where(x => x.Species == species))
            //{
            //    Animals.Remove(animal);
            //    removedAnimalsCount++;
            //}
            Animals.RemoveAll(x => x.Species == species);
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
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
    }
}
