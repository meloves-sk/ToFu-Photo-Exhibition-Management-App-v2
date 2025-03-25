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
    public class DeleteTeamCommand:ICommand
    {
		private readonly TeamViewModel _teamViewModel;
		private readonly ITeamRepository _teamRepository;
		public DeleteTeamCommand(TeamViewModel teamViewModel, ITeamRepository teamRepository)
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
			if (parameter is TeamEntity selectedTeam)
			{
				Guard.IsNull(selectedTeam, "チームが選択されていません");
				var message = await _teamRepository.DeleteTeamAsync(selectedTeam.Id);
				await _teamViewModel.LoadTeamsAsync();
				_teamViewModel.ResetCommand.Execute(null);
				await _teamViewModel.DialogCoordinator.ShowMessageAsync(_teamViewModel, "成功", message);
				_teamViewModel.DialogResult = true;
			}
		}
	}
}
