using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Model
{
	public class StockMeta
	{
		public string version { get; set; }
	}

	public class PrimaryData
	{
		public string lastSalePrice { get; set; }
		public string netChange { get; set; }
		public string percentageChange { get; set; }
		public string deltaIndicator { get; set; }
		public string lastTradeTimestamp { get; set; }
		public bool isRealTime { get; set; }
		public string bidPrice { get; set; }
		public string askPrice { get; set; }
		public string bidSize { get; set; }
		public string askSize { get; set; }
		public string volume { get; set; }
		public object currency { get; set; }
	}

	public class FiftyTwoWeekHighLow
	{
		public string value { get; set; }
	}

	public class KeyStats
	{
		public FiftyTwoWeekHighLow fiftyTwoWeekHighLow { get; set; }
	}

	public class StockBody
	{
		public string symbol { get; set; }
		public string companyName { get; set; }
		public string stockType { get; set; }
		public string exchange { get; set; }
		public PrimaryData primaryData { get; set; }
		public object secondaryData { get; set; }
		public string marketStatus { get; set; }
		public string assetClass { get; set; }
		public KeyStats keyStats { get; set; }
	}

	public class StockPrice
	{
		public StockMeta meta { get; set; }
		public StockBody body { get; set; }
	}
}
