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
		private Visibility _viewVisibility = Visibility.Visible;
		private Visibility _progressVisibility = Visibility.Collapsed;
		public MainViewModel()
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_roundRepository = Factories.CreateRoundRepository();
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			_teamRepository = Factories.CreateTeamRepository();
			_carRepository = Factories.CreateCarRepository();
			_photoRepository = Factories.CreatePhotoRepository();
			RoundDataSetCommand = new DataSetCommand(RoundDataSet, Guard.IsNotAllNull);
			ManufacturerDataSetCommand = new DataSetCommand(ManufacturerDataSet, Guard.IsNotAllNull);
			TeamDataSetCommand = new DataSetCommand(TeamDataSet, Guard.IsNotAllNull);
			CarDataSetCommand = new DataSetCommand(CarDataSet, Guard.IsNotAllNull);
			PhotoDataSetCommand = new DataSetCommand(PhotoDataSet, Guard.IsNotAllNull);
		}
		public ImmutableList<CategoryEntity> CategoryList
		{
			get => _categoryList;
			set
			{
				SetProperty(ref _categoryList, value);
			}
		}
		public ImmutableList<RoundEntity> RoundList
		{
			get => _roundList;
			set
			{
				SetProperty(ref _roundList, value);
			}
		}
		public ImmutableList<ManufacturerEntity> ManufacturerList
		{
			get => _manufacturerList;
			set
			{
				SetProperty(ref _manufacturerList, value);
			}
		}
		public ImmutableList<TeamEntity> TeamList
		{
			get => _teamList;
			set
			{
				SetProperty(ref _teamList, value);
			}
		}
		public ImmutableList<CarEntity> CarList
		{
			get => _carList;
			set
			{
				SetProperty(ref _carList, value);
			}
		}
		public ImmutableList<PhotoEntity> PhotoList
		{
			get => _photoList;
			set
			{
				SetProperty(ref _photoList, value);
			}
		}
		public CategoryEntity? SelectedCategory
		{
			get => _selectedCategory;
			set
			{
				SetProperty(ref _selectedCategory, value);
				if (RoundDataSetCommand.CanExecute(SelectedCategory))
				{
					RoundDataSetCommand.Execute(null);
				}
				if (ManufacturerDataSetCommand.CanExecute(SelectedCategory))
				{
					ManufacturerDataSetCommand.Execute(null);
				}
			}
		}
		public RoundEntity? SelectedRound
		{
			get => _selectedRound;
			set
			{
				SetProperty(ref _selectedRound, value);
				if (PhotoDataSetCommand.CanExecute(SelectedCategory, SelectedRound, SelectedManufacturer, SelectedTeam, SelectedCar))
				{
					PhotoDataSetCommand.Execute(null);
				}
			}
		}
		public ManufacturerEntity? SelectedManufacturer
		{
			get => _selectedManufacturer;
			set
			{
				SetProperty(ref _selectedManufacturer, value);
				if (TeamDataSetCommand.CanExecute(SelectedCategory, SelectedManufacturer))
				{
					TeamDataSetCommand.Execute(null);
				}
			}
		}
		public TeamEntity? SelectedTeam
		{
			get => _selectedTeam;
			set
			{
				SetProperty(ref _selectedTeam, value);
				if (CarDataSetCommand.CanExecute(SelectedCategory, SelectedManufacturer, SelectedTeam))
				{
					CarDataSetCommand.Execute(null);
				}
			}
		}
		public CarEntity? SelectedCar
		{
			get => _selectedCar;
			set
			{
				SetProperty(ref _selectedCar, value);
				if (PhotoDataSetCommand.CanExecute(SelectedCategory, SelectedRound, SelectedManufacturer, SelectedTeam, SelectedCar))
				{
					PhotoDataSetCommand.Execute(null);
				}
			}
		}
		public DataSetCommand RoundDataSetCommand { get; }
		public DataSetCommand ManufacturerDataSetCommand { get; }
		public DataSetCommand TeamDataSetCommand { get; }
		public DataSetCommand CarDataSetCommand { get; }
		public DataSetCommand PhotoDataSetCommand { get; }
		public Visibility ViewVisibility
		{
			get => _viewVisibility;
			set
			{
				SetProperty(ref _viewVisibility, value);
			}
		}
		public Visibility ProgressVisibility
		{
			get => _progressVisibility;
			set
			{
				SetProperty(ref _progressVisibility, value);
			}
		}
		public async Task InitializeAsync()
		{
			ViewVisibility = Visibility.Collapsed;
			ProgressVisibility = Visibility.Visible;
			CategoryList = await _categoryRepository.GetCategoriesWithDefaultAsync();
			SelectedCategory = CategoryList.First();
			ViewVisibility = Visibility.Visible;
			ProgressVisibility = Visibility.Collapsed;
		}
		public async Task RoundDataSet()
		{
			RoundList = await _roundRepository.GetRoundsWithDefaultAsync(
				SelectedCategory!.Id.Value);
			SelectedRound = RoundList.First();
		}
		public async Task ManufacturerDataSet()
		{
			ManufacturerList = await _manufacturerRepository.GetManufacturersWithDefaultAsync(
				SelectedCategory!.Id.Value);
			SelectedManufacturer = ManufacturerList.First();
		}
		public async Task TeamDataSet()
		{
			TeamList = await _teamRepository.GetTeamsWithDefaultAsync(
				SelectedCategory!.Id.Value,
				SelectedManufacturer!.Id.Value);
			SelectedTeam = TeamList.First();
		}
		public async Task CarDataSet()
		{
			CarList = await _carRepository.GetCarsWithDefaultAsync(SelectedCategory!.Id.Value,
				SelectedManufacturer!.Id.Value,
				SelectedTeam!.Id.Value);
			SelectedCar = CarList.First();
		}
		public async Task PhotoDataSet()
		{
			PhotoList = await _photoRepository.GetPhotosAsync(
				SelectedCategory!.Id.Value,
				SelectedRound!.Id.Value,
				SelectedManufacturer!.Id.Value,
				SelectedTeam!.Id.Value,
				SelectedCar!.Id.Value);
		}
	}

}

