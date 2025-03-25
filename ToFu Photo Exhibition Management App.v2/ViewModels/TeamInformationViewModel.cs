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
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;

namespace ToFuPhotoExhibitionManagementApp.v2.ViewModels
{
	public class TeamInformationViewModel : ViewModelBase
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IManufacturerRepository _manufacturerRepository;
		private readonly ITeamRepository _teamRepository;
		private readonly ITeamInformationRepository _teamInformationRepository;
		private ImmutableList<CategoryEntity> _categoryList = ImmutableList<CategoryEntity>.Empty;
		private ImmutableList<ManufacturerEntity> _manufacturerList = ImmutableList<ManufacturerEntity>.Empty;
		private ImmutableList<TeamEntity> _teamList = ImmutableList<TeamEntity>.Empty;
		private ImmutableList<TeamInformationEntity> _teamInformationList = ImmutableList<TeamInformationEntity>.Empty;
		private CategoryEntity? _selectedCategory = null;
		private ManufacturerEntity? _selectedManufacturer = null;
		private TeamEntity? _selectedTeam = null;
		private TeamInformationEntity? _selectedTeamInformation = null;
		private string _status = "Unselected";
		public TeamInformationViewModel(IDialogCoordinator dialogCoordinator)
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			_teamRepository = Factories.CreateTeamRepository();
			_teamInformationRepository = Factories.CreateTeamInformationRepository();
			DialogCoordinator = dialogCoordinator;
		}
		public ImmutableList<CategoryEntity> CategoryList
		{
			get => _categoryList;
			set => SetProperty(ref _categoryList, value);
		}

		public ImmutableList<ManufacturerEntity> ManufacturerList
		{
			get => _manufacturerList;
			set => SetProperty(ref _manufacturerList, value);
		}

		public ImmutableList<TeamEntity> TeamList
		{
			get => _teamList;
			set => SetProperty(ref _teamList, value);
		}
		public ImmutableList<TeamInformationEntity> TeamInformationList
		{
			get => _teamInformationList;
			set => SetProperty(ref _teamInformationList, value);
		}
		public CategoryEntity? SelectedCategory
		{
			get => _selectedCategory;
			set
			{
				SetProperty(ref _selectedCategory, value);
				_ = LoadTeamInformationsAsync();
			}
		}

		public ManufacturerEntity? SelectedManufacturer
		{
			get => _selectedManufacturer;
			set
			{
				SetProperty(ref _selectedManufacturer, value);
				_ = LoadTeamInformationsAsync();
			}
		}

		public TeamEntity? SelectedTeam
		{
			get => _selectedTeam;
			set => SetProperty(ref _selectedTeam, value);
		}

		public TeamInformationEntity? SelectedTeamInformation
		{
			get => _selectedTeamInformation;
			set => SetProperty(ref _selectedTeamInformation, value);
		}
		public string Status
		{
			get => _status;
			set => SetProperty(ref _status, value);
		}
		public IDialogCoordinator DialogCoordinator { get; }
		public bool? DialogResult { get; set; }
		public ICommand ResetCommand => new ResetTeamInformationCommand(this);
		public ICommand SaveCommand => new SaveTeamInformationCommand(this, _teamInformationRepository);
		public ICommand EditCommand => new EditTeamInformationCommand(this);
		public ICommand DeleteCommand => new DeleteTeamInformationCommand(this, _teamInformationRepository);
		public async Task InitializeAsync()
		{
			CategoryList = await _categoryRepository.GetCategoriesAsync();
			SelectedCategory = CategoryList.FirstOrDefault();
			ManufacturerList = await _manufacturerRepository.GetManufacturersAsync(new Id(0));
			SelectedManufacturer = ManufacturerList.FirstOrDefault();
			TeamList = await _teamRepository.GetTeamsAsync(new Id(0), new Id(0));
			SelectedTeam = TeamList.FirstOrDefault();
		}
		public async Task LoadTeamInformationsAsync()
		{
			TeamInformationList = await _teamInformationRepository.GetTeamInformationsAsync(SelectedCategory?.Id, SelectedManufacturer?.Id);
		}
	}
}
