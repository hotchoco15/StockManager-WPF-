using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace StockManager.ViewModel.ValueConverters
{
	public class ColorChangeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
			{
				return Brushes.Black;
			}
			else 
			{
				return (value.ToString()).Contains("+") ? Brushes.Red
					: (value.ToString()).Contains("-") ? Brushes.Blue : Brushes.Black;  
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
