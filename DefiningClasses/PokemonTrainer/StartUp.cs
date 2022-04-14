using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] information = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = information[0];
                string pockemonName = information[1];
                string pokemonElement = information[2];
                BigInteger pokemonHealth = BigInteger.Parse(information[3]);

             
                Pokemon pokemon = new Pokemon(pockemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = new Trainer(trainerName,new List<Pokemon> { pokemon });
                    trainers.Add(trainer);
                }
                else
                {

                    var currentTrainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                    currentTrainer.Pokemons.Add(pokemon);

                    
                }

            }

            string actions;

            while ((actions = Console.ReadLine()) != "End")
            {
                ActionApplyer(trainers,actions);
            }

            var orderedTrainers = trainers.OrderByDescending(x => x.NumberOfBadges);

            foreach (var trainer in orderedTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
        public static void ActionApplyer(List<Trainer> trainers,string element)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(y=>y.Element == element))
                {
                    trainer.NumberOfBadges++;
                }
                else
                {
                    PockemonDecreaser(trainer);
                }
            }
        }
        public static void PockemonDecreaser(Trainer trainer)
        {
            List<Pokemon> pockemonsForRemove = new List<Pokemon>();

            foreach (var pockemon in trainer.Pokemons)
            {
                pockemon.Health -= 10;

                if (pockemon.Health <= 0)
                {
                    pockemonsForRemove.Add(pockemon);
                }

                if (trainer.Pokemons.Count == 0)
                {
                    break;
                }
            }

            foreach (var item in pockemonsForRemove)
            {
                trainer.Pokemons.Remove(item);
            }
        }
    }
}
 