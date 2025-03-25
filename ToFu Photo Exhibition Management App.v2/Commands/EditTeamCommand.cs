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
	public class EditTeamCommand : ICommand
	{
		private readonly TeamViewModel _teamViewModel;
		public EditTeamCommand(TeamViewModel teamViewModel)
		{
			_teamViewModel = teamViewModel;
			_teamViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			if (parameter is TeamEntity selectedTeam)
			{
				_teamViewModel.SelectedTeam = selectedTeam;
				_teamViewModel.Status = $"Selected: {selectedTeam.Name.Value}";
				_teamViewModel.TeamName = selectedTeam.Name.Value;
			}
		}
	}
}
