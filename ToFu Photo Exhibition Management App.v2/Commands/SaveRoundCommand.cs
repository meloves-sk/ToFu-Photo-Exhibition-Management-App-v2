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
	public class SaveRoundCommand : ICommand
	{
		private readonly RoundViewModel _roundViewModel;
		private readonly IRoundRepository _roundRepository;
		public SaveRoundCommand(RoundViewModel roundViewModel, IRoundRepository roundRepository)
		{
			_roundViewModel = roundViewModel;
			_roundRepository = roundRepository;
			_roundViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			Guard.IsNull(_roundViewModel.SelectedCategory, "カテゴリを選択してください");
			Guard.IsFail(_roundViewModel.RoundName != string.Empty, "ラウンド名を入力してください");
			var message = await _roundRepository.SaveRoundAsync(_roundViewModel.SelectedRound?.Id, _roundViewModel.RoundName, _roundViewModel.SelectedCategory!.Id);
			await _roundViewModel.LoadRoundsAsync();
			_roundViewModel.ResetCommand.Execute(null);
			await _roundViewModel.DialogCoordinator.ShowMessageAsync(_roundViewModel, "成功", message);
			_roundViewModel.DialogResult = true;
		}
	}
}
