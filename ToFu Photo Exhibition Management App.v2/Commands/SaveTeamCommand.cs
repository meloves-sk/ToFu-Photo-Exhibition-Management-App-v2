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
    public class SaveTeamCommand:ICommand
    {
		private readonly TeamViewModel _teamViewModel;
		private readonly ITeamRepository _teamRepository;
		public SaveTeamCommand(TeamViewModel teamViewModel, ITeamRepository teamRepository)
		{
			_teamViewModel = teamViewModel;
			_teamRepository = teamRepository;
			_teamViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			Guard.IsFail(_teamViewModel.TeamName != string.Empty, "チーム名を入力してください");
			var message = await _teamRepository.SaveTeamAsync(_teamViewModel.SelectedTeam?.Id, _teamViewModel.TeamName);
			await _teamViewModel.LoadTeamsAsync();
			_teamViewModel.ResetCommand.Execute(null);
			await _teamViewModel.DialogCoordinator.ShowMessageAsync(_teamViewModel, "成功", message);
			_teamViewModel.DialogResult = true;
		}
	}
}
