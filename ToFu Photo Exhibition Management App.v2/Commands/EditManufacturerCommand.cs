using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class EditManufacturerCommand : ICommand
	{
		private readonly ManufacturerViewModel _manufacturerViewModel;
		public EditManufacturerCommand(ManufacturerViewModel manufacturerViewModel)
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
			if (parameter is ManufacturerEntity selectedManufacturer)
			{
				_manufacturerViewModel.SelectedManufacturer = selectedManufacturer;
				_manufacturerViewModel.Status = $"Selected: {selectedManufacturer.Name.Value}";
				_manufacturerViewModel.ManufacturerName = selectedManufacturer.Name.Value;
			}
		}
	}
}
