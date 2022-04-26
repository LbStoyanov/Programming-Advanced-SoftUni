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
            this.Species = species;
            this.Diet = diet;
            this.Weight = weight;
            this.Lenght = lenght;
        }
        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Lenght { get; set; }

        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }
    }
}
