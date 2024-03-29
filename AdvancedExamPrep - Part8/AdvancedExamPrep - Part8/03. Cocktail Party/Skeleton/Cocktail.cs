﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name)&& Capacity > 0 && ingredient.Alcohol <= MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                Ingredient ingredientForRemove = Ingredients.FirstOrDefault(x => x.Name == name);
                Ingredients.Remove(ingredientForRemove);
                return true;
            }

            return false;
        }
         public Ingredient FindIngredient(string name)
         {
            if (Ingredients.Any(x =>x.Name == name))
            {
                Ingredient ingredient = Ingredients.FirstOrDefault(x => x.Name == name);
                return ingredient;
            }

            return null;
         }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholicIngredient = Ingredients.OrderByDescending(x => x.Alcohol).First();
            return mostAlcoholicIngredient;
        }

        public int CurrentAlcoholLevel
            => this.Ingredients.Sum(x => x.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
              sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
