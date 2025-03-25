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
	public class EditCarCommand : ICommand
	{
		private readonly CarViewModel _carViewModel;
		public EditCarCommand(CarViewModel carViewModel)
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
			if (parameter is CarEntity selectedCar)
			{
				_carViewModel.SelectedCar = selectedCar;
				_carViewModel.SelectedCategory = _carViewModel.CategoryList.First(a => a.Name.Value == selectedCar.Category.Value);
				_carViewModel.SelectedManufacturer = _carViewModel.ManufacturerList.First(a => a.Name.Value == selectedCar.Manufacturer.Value);
				_carViewModel.SelectedTeamInformation = _carViewModel.TeamInformationList.First(a => a.Id.Value == selectedCar.TeamInformationId.Value);
				_carViewModel.CarName = selectedCar.Name.Value;
				_carViewModel.CarNo = selectedCar.CarNo.Value;
				_carViewModel.Status = $"Selected: CarNo.{selectedCar.CarNo.Value} {selectedCar.Name.Value}";
			}
		}
	}
}
