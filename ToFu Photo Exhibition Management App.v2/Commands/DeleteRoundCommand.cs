using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class DeleteRoundCommand : ICommand
	{
		private readonly RoundViewModel _roundViewModel;
		private readonly IRoundRepository _roundRepository;
		public DeleteRoundCommand(RoundViewModel roundViewModel, IRoundRepository roundRepository)
		{
			_roundViewModel = roundViewModel;
			_roundRepository = roundRepository;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			if (parameter is RoundEntity selectedRound)
			{
				Guard.IsNull(selectedRound, "ラウンドが選択されていません");
				var message = await _roundRepository.DeleteRoundAsync(selectedRound.Id);
				await _roundViewModel.LoadRoundsAsync();
				_roundViewModel.SelectedRound = null;
				await _roundViewModel.DialogCoordinator.ShowMessageAsync(_roundViewModel, "成功", message);
				_roundViewModel.DialogResult = true;
			}
		}
	}
}
