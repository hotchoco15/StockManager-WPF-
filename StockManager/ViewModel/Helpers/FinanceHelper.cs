using Newtonsoft.Json;
using StockManager.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace StockManager.ViewModel.Helpers
{
	public class FinanceHelper
	{
		public const string BASE_URL = "https://yahoo-finance15.p.rapidapi.com/";
		public const string ENDPOINT_FOR_STOCKPRICE = "api/v1/markets/quote?ticker={0}&type=STOCKS";
		public const string ENDPOINT_FOR_HISTORY = "api/v1/markets/stock/history?symbol={0}&interval=1d&diffandsplits=false";
		public const string API_KEY = "YOUR_API_KEY_HERE";
		public const string API_HOST = "yahoo-finance15.p.rapidapi.com";
		public const string BASE_URL_FOR_TICKER = "BASE_URL_FOR_TICKER";
		public const string ENDPOINT_FOR_TICKER = "keyword/{0}";



		public static async Task<List<Ticker>> GetTickers(string query)
		{
			// ticker 조회 
			List<Ticker> tickers = new List<Ticker>();

			string url = BASE_URL_FOR_TICKER + string.Format(ENDPOINT_FOR_TICKER, query);

			using(HttpClient client = new HttpClient())
			{
				var response = await client.GetAsync(url);
				string json = await response.Content.ReadAsStringAsync();

				try 
				{
					tickers = JsonConvert.DeserializeObject<List<Ticker>>(json);
				}
				catch (Exception ex) 
				{
					Console.WriteLine(ex.Message);
				}
			}
			return tickers;
		}

		public static async Task<StockPrice> GetStockPrices(string symbol)
		{
			// 조회
			StockPrice stockPrice = new StockPrice();

			string url = BASE_URL + string.Format(ENDPOINT_FOR_STOCKPRICE, symbol);

			using (HttpClient client = new HttpClient())
			{

				client.DefaultRequestHeaders.Add("x-rapidapi-key", API_KEY);
				client.DefaultRequestHeaders.Add("x-rapidapi-host", API_HOST);

				var response = await client.GetAsync(url);
				string json = await response.Content.ReadAsStringAsync();

				try
				{
					stockPrice = JsonConvert.DeserializeObject<StockPrice>(json);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}

			return stockPrice;
		}


		
	}
}
