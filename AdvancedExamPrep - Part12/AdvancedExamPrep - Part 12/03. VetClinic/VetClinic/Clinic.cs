using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            Pets = new List<Pet>();
        }

        public List<Pet> Pets
        {
            get { return pets; }
            set { pets = value; }
        }

        public int Capacity { get; set; }

        public int Count 
            => Pets.Count;

        public void Add(Pet pet)
        {
            if (Capacity > 0)
            {
                Pets.Add(pet);
                Capacity--;
            }
        }

        public bool Remove(string name)
        {
            if (Pets.Any(p => p.Name == name))
            {
                Pet petToRemove = Pets.FirstOrDefault(p => p.Name == name);

                Pets.Remove(petToRemove);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            if (Pets.Any(x => x.Name == name && x.Owner == owner))
            {
                return Pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            }

            return null;
        }

        public Pet GetOldestPet()
        {
            //Check if there is any pets at all!
            Pet oldestPet = Pets.OrderByDescending(x => x.Age).First();
            return oldestPet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients: ");

            foreach (var pet in Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
