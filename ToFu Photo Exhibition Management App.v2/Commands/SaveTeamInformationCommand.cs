using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class SaveTeamInformationCommand : ICommand
	{
		private readonly TeamInformationViewModel _teamInformationViewModel;
		private readonly ITeamInformationRepository _teamInformationRepository;
		public SaveTeamInformationCommand(TeamInformationViewModel teamInformationViewModel, ITeamInformationRepository teamInformationRepository)
		{
			_teamInformationViewModel = teamInformationViewModel;
			_teamInformationRepository = teamInformationRepository;
			_teamInformationViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			Guard.IsNull(_teamInformationViewModel.SelectedCategory, "カテゴリーが選択されていません");
			Guard.IsNull(_teamInformationViewModel.SelectedManufacturer, "メーカーが選択されていません");
			Guard.IsNull(_teamInformationViewModel.SelectedTeam, "チームが選択されていません");
			var message = await _teamInformationRepository.SaveTeamInformationAsync(_teamInformationViewModel.SelectedTeamInformation?.Id, _teamInformationViewModel.SelectedTeam!.Id, _teamInformationViewModel.SelectedManufacturer!.Id, _teamInformationViewModel.SelectedCategory!.Id);
			await _teamInformationViewModel.LoadTeamInformationsAsync();
			_teamInformationViewModel.ResetCommand.Execute(null);
			await _teamInformationViewModel.DialogCoordinator.ShowMessageAsync(_teamInformationViewModel, "成功", message);
			_teamInformationViewModel.DialogResult = true;
		}
	}
}
