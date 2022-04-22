namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double lenght;

        public Animal(string species,string diet,double weight,double lenght)
        {
            this.species = species;
            this.diet = diet;
            this.weight = weight;
            this.lenght = lenght;
        }
        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Lenght { get; set; }

        public override string ToString()
        {
            return $"The {this.species} is a {this.diet} and weighs {this.weight} kg.";
        }
    }
}
