using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockManager.ViewModel.Commands
{
	public class SearchCommand : ICommand
	{
        public StockVM VM { get; set; }

        public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

        public SearchCommand(StockVM vm)
        {
            VM = vm;	
        }

        public bool CanExecute(object parameter)
		{
			string query = parameter as string;

			if(string.IsNullOrWhiteSpace(query)) 
			{
				return false;
			}
			return true;
		}

		public void Execute(object parameter)
		{
			VM.MakeQuery();
		}
	}
}
