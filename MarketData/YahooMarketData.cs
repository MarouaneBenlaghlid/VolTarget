using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace MarketData
{
    public class YahooMarketData
    {
        public async Task<List<decimal>> GetUnderlyingClosePriceAsync(string symbol, DateTime startDate, DateTime endDate)
        {
            var historicData = await Yahoo.GetHistoricalAsync(symbol, startDate, endDate);
            var security = await Yahoo.Symbols(symbol).Fields(Field.LongName).QueryAsync();
            var ticker = security[symbol];
            var companyName = ticker[Field.LongName];
            var listToReturn = new List<decimal>();
            for (int i = 0; i < historicData.Count; i++)
            {
                listToReturn.Add(historicData.ElementAt(i).Close);
            }
            return listToReturn;
        }
    }
}

