using System.Collections.Generic;
using System.Linq;

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
            if (stock.MarketCapitalization > shareCeiling && this.MoneyToInvest >= shareCeiling)
            {
                this.Portfolio.Add(stock);
                this.MoneyToInvest -= stock.MarketCapitalization;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stockToBeSelled = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (!this.Portfolio.Contains(stockToBeSelled))
            {
                return $"{companyName} does not exist.";
            }

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

            var orderedByMaxMarketCapitalizationPortFolio = this.Portfolio.OrderBy(x => x.MarketCapitalization).Max();

            Stock stock = orderedByMaxMarketCapitalizationPortFolio;

            return stock;
            
        }
        public string InvestorInformation()
        {


            return $"The investor {this.FullName} with a broker {this.BrokerName} has stocks:\n{string.Join} ";
        }
    }
}
