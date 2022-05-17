using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private const int shareCeiling = 10_000; 
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new HashSet<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string  BrokerName { get; set; }
        public HashSet<Stock> Portfolio { get; set; }
        public int Count 
            => this.Portfolio.Count;
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > shareCeiling && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            
            if (!this.Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            Stock stockToBeSelled = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (sellPrice < stockToBeSelled.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            this.Portfolio.Remove(stockToBeSelled);
            this.MoneyToInvest += sellPrice;

            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            Stock stock = this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (!this.Portfolio.Contains(stock))
            {
                return null;
            }

            return stock;
        }
        public Stock FindBiggestCompany()
        {
            if (this.Portfolio.Count == 0)
            {
                return null;
            }

            Stock stock = this.Portfolio.OrderByDescending(x => x.MarketCapitalization).First();

            return stock;
            
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                sb.AppendLine($"Company: {stock.CompanyName}");
                sb.AppendLine($"Director: {stock.Director}");
                sb.AppendLine($"Price per share: ${stock.PricePerShare}");
                sb.AppendLine($"Market capitalization: ${stock.MarketCapitalization}");
            }

            return sb.ToString();
        }
    }
}
