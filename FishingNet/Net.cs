using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net 
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }
        public List<Fish> Fish { get; set; }

        public int Count => Fish.Count; 


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
                var fishToRemove = Fish.FirstOrDefault(x => x.Weight == weight);
                Fish.Remove(fishToRemove);
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
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}: ");

            var orderedCollectionOfFishes = Fish.OrderByDescending(x => x.Lenght).ToList();

            foreach (var item in orderedCollectionOfFishes)
            {
                sb.AppendLine($"There is a {item.FishType}, {item.Lenght} cm. long, and {item.Weight} gr. in weight.");
            }

            return sb.ToString();
        }
    }
}
