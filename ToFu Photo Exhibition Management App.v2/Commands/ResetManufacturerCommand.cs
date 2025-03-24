using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class ResetManufacturerCommand : ICommand
	{
		private readonly ManufacturerViewModel _manufacturerViewModel;
		public ResetManufacturerCommand(ManufacturerViewModel manufacturerViewModel)
		{
			_manufacturerViewModel = manufacturerViewModel;
			_manufacturerViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			_manufacturerViewModel.SelectedManufacturer = null;
			_manufacturerViewModel.Status = "Unselected";
			_manufacturerViewModel.ManufacturerName = string.Empty;
		}
	}
}
