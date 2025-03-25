using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
using ToFuPhotoExhibitionManagementApp.v2.Views;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class SaveCarCommand : ICommand
	{
		private readonly CarViewModel _carViewModel;
		private readonly ICarRepository _carRepository;
		public SaveCarCommand(CarViewModel carViewModel, ICarRepository carRepository)
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
			Guard.IsNull(_carViewModel.SelectedTeamInformation, "チーム情報を選択してください");
			Guard.IsFail(_carViewModel.CarName != string.Empty, "車両名を入力してください");
			Guard.IsNull(_carViewModel.CarNo, "車両番号を入力してください");
			var message = await _carRepository.SaveCarAsync(_carViewModel.SelectedCar?.Id, _carViewModel.CarName, _carViewModel.CarNo!.Value, _carViewModel.SelectedTeamInformation!.Id);
			await _carViewModel.LoadCarsAsync();
			_carViewModel.ResetCommand.Execute(null);
			await _carViewModel.DialogCoordinator.ShowMessageAsync(_carViewModel, "成功", message);
			_carViewModel.DialogResult = true;
		}
	}
}
