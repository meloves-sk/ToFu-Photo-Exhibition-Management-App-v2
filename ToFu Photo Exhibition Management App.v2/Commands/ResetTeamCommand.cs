using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
    public class ResetTeamCommand:ICommand
    {
		private readonly TeamViewModel _teamViewModel;
		public ResetTeamCommand(TeamViewModel teamViewModel)
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
			_teamViewModel.SelectedTeam = null;
			_teamViewModel.Status = "Unselected";
			_teamViewModel.TeamName = string.Empty;
		}
	}
}
