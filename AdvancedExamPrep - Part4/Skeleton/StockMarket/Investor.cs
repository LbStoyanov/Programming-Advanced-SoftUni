using System.Collections.Generic;

namespace StockMarket
{
    public class Investor
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string  BrokerName { get; set; }
        public HashSet<Stock> Portfolio { get; set; }
    }
}
