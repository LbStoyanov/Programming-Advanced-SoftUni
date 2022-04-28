namespace FishingNet
{
    public class Fish
    {
        private string fishType;
        private double length;
        private double weight;

        public Fish(string fishType,double lenght,double weight)
        {
            this.FishType = fishType;
            this.Lenght = lenght;
            this.Weight = weight;
        }
        public string FishType { get; set; }
        public double Lenght { get; set; }

        public double Weight { get; set; }

        public override string ToString()
        {
            return $"There is a {this.fishType}, {this.length} cm. long, and {this.weight} gr. in weight.";
        }
    }
}
