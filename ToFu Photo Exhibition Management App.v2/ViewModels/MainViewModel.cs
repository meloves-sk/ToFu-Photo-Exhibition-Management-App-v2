using MahApps.Metro.Controls.Dialogs;
using System.Collections.Immutable;
using System.Windows;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Commands;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure;

namespace ToFuPhotoExhibitionManagementApp.v2.ViewModels
{
	public class MainViewModel : ViewModelBase
	{
		private ICategoryRepository _categoryRepository;
		private IRoundRepository _roundRepository;
		private IManufacturerRepository _manufacturerRepository;
		private ITeamRepository _teamRepository;
		private ICarRepository _carRepository;
		private IPhotoRepository _photoRepository;
		private ImmutableList<CategoryEntity> _categoryList = ImmutableList<CategoryEntity>.Empty;
		private ImmutableList<RoundEntity> _roundList = ImmutableList<RoundEntity>.Empty;
		private ImmutableList<ManufacturerEntity> _manufacturerList = ImmutableList<ManufacturerEntity>.Empty;
		private ImmutableList<TeamEntity> _teamList = ImmutableList<TeamEntity>.Empty;
		private ImmutableList<CarEntity> _carList = ImmutableList<CarEntity>.Empty;
		private ImmutableList<PhotoEntity> _photoList = ImmutableList<PhotoEntity>.Empty;
		private CategoryEntity? _selectedCategory = null;
		private RoundEntity? _selectedRound = null;
		private ManufacturerEntity? _selectedManufacturer = null;
		private TeamEntity? _selectedTeam = null;
		private CarEntity? _selectedCar = null;
		private PhotoEntity? _selectedPhoto = null;
		public MainViewModel(IDialogCoordinator dialogCoordinator)
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_roundRepository = Factories.CreateRoundRepository();
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			_teamRepository = Factories.CreateTeamRepository();
			_carRepository = Factories.CreateCarRepository();
			_photoRepository = Factories.CreatePhotoRepository();
			DialogCoordinator = dialogCoordinator;
		}
		public ImmutableList<CategoryEntity> CategoryList
		{
			get => _categoryList;
			set => SetProperty(ref _categoryList, value);
		}

		public ImmutableList<RoundEntity> RoundList
		{
			get => _roundList;
			set => SetProperty(ref _roundList, value);
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

		public ImmutableList<CarEntity> CarList
		{
			get => _carList;
			set => SetProperty(ref _carList, value);
		}

		public ImmutableList<PhotoEntity> PhotoList
		{
			get => _photoList;
			set => SetProperty(ref _photoList, value);
		}

		public CategoryEntity? SelectedCategory
		{
			get => _selectedCategory;
			set
			{
				SetProperty(ref _selectedCategory, value);
				_ = LoadRoundsAsync();
				_ = LoadManufacturersAsync();
			}
		}

		public RoundEntity? SelectedRound
		{
			get => _selectedRound;
			set
			{
				SetProperty(ref _selectedRound, value);
				_ = LoadPhotosAsync();
			}
		}

		public ManufacturerEntity? SelectedManufacturer
		{
			get => _selectedManufacturer;
			set
			{
				SetProperty(ref _selectedManufacturer, value);
				_ = LoadTeamsAsync();
			}
		}

		public TeamEntity? SelectedTeam
		{
			get => _selectedTeam;
			set
			{
				SetProperty(ref _selectedTeam, value);
				_ = LoadCarsAsync();
			}
		}

		public CarEntity? SelectedCar
		{
			get => _selectedCar;
			set
			{
				SetProperty(ref _selectedCar, value);
				_ = LoadPhotosAsync();
			}
		}

		public PhotoEntity? SelectedPhoto
		{
			get => _selectedPhoto;
			set
			{
				SetProperty(ref _selectedPhoto, value);
				if (Guard.NotAllNull(_selectedPhoto))
				{
					ShowPhotoViewCommand.Execute(null);
				}
			}
		}
		public IDialogCoordinator DialogCoordinator { get; }

		public ICommand ShowPhotoViewCommand => new ShowPhotoViewCommand(this);
		public ICommand ShowRoundViewCommand => new ShowRoundViewCommand(this);
		public ICommand ShowManufacturerViewCommand => new ShowManufacturerViewCommand(this);

		public async Task InitializeAsync()
		{
			var controller = await DialogCoordinator.ShowProgressAsync(this, "", "読み込み中");
			CategoryList = await _categoryRepository.GetCategoriesWithDefaultAsync();
			SelectedCategory = CategoryList.FirstOrDefault();
			await controller.CloseAsync();
		}
		public async Task LoadRoundsAsync()
		{
			RoundList = await _roundRepository.GetRoundsWithDefaultAsync(SelectedCategory?.Id);
			SelectedRound = RoundList.First();
		}
		public async Task LoadManufacturersAsync()
		{
			ManufacturerList = await _manufacturerRepository.GetManufacturersWithDefaultAsync(SelectedCategory?.Id);
			SelectedManufacturer = ManufacturerList.First();
		}
		public async Task LoadTeamsAsync()
		{
			TeamList = await _teamRepository.GetTeamsWithDefaultAsync(SelectedCategory?.Id, SelectedManufacturer?.Id);
			SelectedTeam = TeamList.First();
		}
		public async Task LoadCarsAsync()
		{
			CarList = await _carRepository.GetCarsWithDefaultAsync(SelectedCategory?.Id, SelectedManufacturer?.Id, SelectedTeam?.Id);
			SelectedCar = CarList.First();
		}
		public async Task LoadPhotosAsync()
		{
			PhotoList = await _photoRepository.GetPhotosAsync(SelectedCategory?.Id, SelectedRound?.Id, SelectedManufacturer?.Id, SelectedTeam?.Id, SelectedCar?.Id);
		}
	}

}

