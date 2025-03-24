using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
using ToFuPhotoExhibitionManagementApp.v2.Views;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class ShowManufacturerViewCommand : ICommand
	{
		private readonly MainViewModel _mainViewModel;
		public ShowManufacturerViewCommand(MainViewModel mainViewModel)
		{
			_mainViewModel = mainViewModel;
			_mainViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			var manufacturerView = new ManufacturerView();
			if (manufacturerView.ShowDialog() == true)
			{
				await _mainViewModel.LoadManufacturersAsync();
			}
		}
	}
}
