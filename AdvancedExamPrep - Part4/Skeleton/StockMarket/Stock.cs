namespace StockMarket
{
    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal  PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization 
            => this.PricePerShare * this.TotalNumberOfShares;

        public override string ToString()
        {
            return $"Company: {this.CompanyName}\nDirector: {this.Director}\nPrice per share: ${this.PricePerShare}\nMarket capitalization: ${this.MarketCapitalization}";
        }
    }
}
