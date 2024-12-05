using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using StockManager.Model;
using StockManager.View;
using StockManager.ViewModel.Commands;
using StockManager.ViewModel.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockManager.ViewModel
{
	public class StockVM : INotifyPropertyChanged
	{
		private string query;

		public string Query
		{
			get { return query; }
			set
			{
				query = value;
				OnPropertyChanged(nameof(Query));
			}
		}

        public ObservableCollection<Ticker> Tickers { get; set; }

        private Ticker selectedTicker;

		public Ticker SelectedTicker
		{
			get { return selectedTicker; }
			set
			{
				selectedTicker = value;
				OnPropertyChanged(nameof(SelectedTicker));


				
				GetSalePrice();
			}
		}


		private StockPrice stockPrice;

		public StockPrice StockPrice
		{
			get { return stockPrice; }
			set 
			{ 
				stockPrice = value; 
				OnPropertyChanged(nameof(StockPrice));
			}
		}

	

		private async void GetSalePrice()
		{
			Query = string.Empty;
			//Tickers.Clear();
			StockPrice = new StockPrice
			{
				body = new StockBody
				{
					companyName = string.Empty,
					primaryData = new PrimaryData
					{
						lastSalePrice = string.Empty,
						netChange = string.Empty,
						percentageChange = string.Empty
					}
				}
			};
			StockPrice = await FinanceHelper.GetStockPrices(SelectedTicker.symbol);
		}

		public SearchCommand SearchCommand { get; set; }


        public StockVM()
		{
			if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
			{
				SelectedTicker = new Ticker
				{
					name = "Microsoft"
				};

			}

			SearchCommand = new SearchCommand(this);

			Tickers = new ObservableCollection<Ticker>();
		}

		public async void MakeQuery()
		{
			var tickers = await FinanceHelper.GetTickers(Query);

			Tickers.Clear();
			foreach (Ticker ticker in tickers) 
			{
				Tickers.Add(ticker);
			}
		}

		
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		
	}
}
