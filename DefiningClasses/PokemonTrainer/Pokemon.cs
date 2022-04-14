using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string name,string element, BigInteger health)
        {
            Name = name;
            Element = element;
            Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public BigInteger Health { get; set; }
    }
}
