using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
    public class ResetTeamInformationCommand:ICommand
    {
		private readonly TeamInformationViewModel _teamInformationViewModel;
		public ResetTeamInformationCommand(TeamInformationViewModel teamInformationViewModel)
		{
			_teamInformationViewModel = teamInformationViewModel;
			_teamInformationViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			_teamInformationViewModel.SelectedTeamInformation = null;
			_teamInformationViewModel.Status = "Unselected";
		}
	}
}
