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
	public class EditTeamInformationCommand : ICommand
	{
		private readonly TeamInformationViewModel _teamInformationViewModel;
		public EditTeamInformationCommand(TeamInformationViewModel teamInformationViewModel)
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
			if (parameter is TeamInformationEntity selectedTeamInformation)
			{
				_teamInformationViewModel.SelectedTeamInformation = selectedTeamInformation;
				_teamInformationViewModel.SelectedCategory = _teamInformationViewModel.CategoryList.First(a => a.Name.Value == selectedTeamInformation.Category.Value);
				_teamInformationViewModel.SelectedManufacturer = _teamInformationViewModel.ManufacturerList.First(a => a.Name.Value == selectedTeamInformation.Manufacturer.Value);
				_teamInformationViewModel.SelectedTeam = _teamInformationViewModel.TeamList.First(a => a.Name.Value == selectedTeamInformation.Team.Value);
				_teamInformationViewModel.Status = $"Selected: {selectedTeamInformation.Category.Value} {selectedTeamInformation.Manufacturer.Value} {selectedTeamInformation.Team.Value}";
			}
		}
	}
}
