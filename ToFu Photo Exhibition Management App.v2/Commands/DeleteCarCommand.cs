using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
    public class DeleteCarCommand:ICommand
    {
		private readonly CarViewModel _carViewModel;
		private readonly ICarRepository _carRepository;
		public DeleteCarCommand(CarViewModel carViewModel, ICarRepository carRepository)
		{
			_carViewModel = carViewModel;
			_carRepository = carRepository;
			_carViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			if (parameter is CarEntity selectedCar)
			{
				Guard.IsNull(selectedCar, "車両が選択されていません");
				var message = await _carRepository.DeleteCarAsync(selectedCar.Id);
				await _carViewModel.LoadCarsAsync();
				_carViewModel.ResetCommand.Execute(null);
				await _carViewModel.DialogCoordinator.ShowMessageAsync(_carViewModel, "成功", message);
				_carViewModel.DialogResult = true;
			}
		}
	}
}
