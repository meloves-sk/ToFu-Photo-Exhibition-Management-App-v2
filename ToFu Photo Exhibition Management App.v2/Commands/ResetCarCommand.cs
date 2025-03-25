using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
    public class ResetCarCommand:ICommand
    {
		private readonly CarViewModel _carViewModel;
		public ResetCarCommand(CarViewModel carViewModel)
		{
			_carViewModel = carViewModel;
			_carViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			_carViewModel.SelectedCar = null;
			_carViewModel.Status = "Unselected";
		}
	}
}
