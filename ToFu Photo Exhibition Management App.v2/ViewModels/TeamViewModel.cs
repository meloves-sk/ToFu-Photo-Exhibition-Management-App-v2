using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Commands;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure;

namespace ToFuPhotoExhibitionManagementApp.v2.ViewModels
{
	public class TeamViewModel : ViewModelBase
	{
		private readonly ITeamRepository _teamRepository;
		private ImmutableList<TeamEntity> _teamList = ImmutableList<TeamEntity>.Empty;
		private TeamEntity? _selectedTeam = null;
		private string _teamName = string.Empty;
		private string _status = "Unselected";
		public TeamViewModel(IDialogCoordinator dialogCoordinator)
		{
			_teamRepository = Factories.CreateTeamRepository();
			DialogCoordinator = dialogCoordinator;
		}
		public ImmutableList<TeamEntity> TeamList
		{
			get => _teamList;
			set => SetProperty(ref _teamList, value);
		}

		public TeamEntity? SelectedTeam
		{
			get => _selectedTeam;
			set => SetProperty(ref _selectedTeam, value);
		}
		public string TeamName
		{
			get => _teamName;
			set => SetProperty(ref _teamName, value);
		}
		public string Status
		{
			get => _status;
			set => SetProperty(ref _status, value);
		}
		public IDialogCoordinator DialogCoordinator { get; }
		public bool? DialogResult { get; set; }
		public ICommand ResetCommand => new ResetTeamCommand(this);
		public ICommand SaveCommand => new SaveTeamCommand(this, _teamRepository);
		public ICommand EditCommand => new EditTeamCommand(this);
		public ICommand DeleteCommand => new DeleteTeamCommand(this, _teamRepository);
		public async Task InitializeAsync()
		{
			await LoadTeamsAsync();
		}
		public async Task LoadTeamsAsync()
		{
			TeamList = await _teamRepository.GetTeamsAsync(new Id(0),new Id(0));
		}
	}
}
