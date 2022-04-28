using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net 
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            
        }
        public List<Fish> Fish { get; set; } = new List<Fish>();
        

        public string Material { get; set; }
        public int Capacity { get; set; }

        public string AddFish(Fish fish)
        {
            if (Capacity == 0)
            {
                return "Fishing net is full.";
            }

            Capacity--;

            if ((fish.FishType == null || fish.FishType == " ") && fish.Lenght == 0 || fish.Weight == 0)
            {
                return "Invalid fish.";
            }
            

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(x => x.Weight == weight))
            {
                Fish.RemoveAll(x => x.Weight == weight);
                return true;
            }

            return false;
        }
        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(x => x.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            double maxLenght = 0;

            foreach (var item in Fish)
            {
                if (item.Weight > maxLenght)
                {
                    maxLenght = item.Weight;
                }
            }

            return Fish.Find(x => x.Weight == maxLenght);
        }
        public void Report()
        {

        }
    }
}
