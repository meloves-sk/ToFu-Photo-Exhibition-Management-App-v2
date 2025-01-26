using System.Collections.Immutable;
using System.Windows;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Commands;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure;

namespace ToFuPhotoExhibitionManagementApp.v2.ViewModels
{
	public class PhotoViewModel : ViewModelBase
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IRoundRepository _roundRepository;
		private readonly IManufacturerRepository _manufacturerRepository;
		private readonly ITeamRepository _teamRepository;
		private readonly ICarRepository _carRepository;
		private readonly IPhotoRepository _photoRepository;

		private ImmutableList<CategoryEntity> _categoryList = ImmutableList<CategoryEntity>.Empty;
		private ImmutableList<RoundEntity> _roundList = ImmutableList<RoundEntity>.Empty;
		private ImmutableList<ManufacturerEntity> _manufacturerList = ImmutableList<ManufacturerEntity>.Empty;
		private ImmutableList<TeamEntity> _teamList = ImmutableList<TeamEntity>.Empty;
		private ImmutableList<CarEntity> _carList = ImmutableList<CarEntity>.Empty;

		private CategoryEntity? _selectedCategory;
		private RoundEntity? _selectedRound;
		private ManufacturerEntity? _selectedManufacturer;
		private TeamEntity? _selectedTeam;
		private CarEntity? _selectedCar;

		private string _filePath = string.Empty;
		private string _description = string.Empty;

		private Visibility _uploadVisibility = Visibility.Visible;
		private Visibility _deleteVisibility = Visibility.Collapsed;
		private Visibility _viewVisibility = Visibility.Visible;
		private Visibility _progressVisibility = Visibility.Collapsed;

		private bool _isInitialize = true;

		public PhotoViewModel(PhotoEntity? selectedPhoto = null)
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_roundRepository = Factories.CreateRoundRepository();
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			_teamRepository = Factories.CreateTeamRepository();
			_carRepository = Factories.CreateCarRepository();
			_photoRepository = Factories.CreatePhotoRepository();
			SelectedPhoto = selectedPhoto;
			UploadVisibility = Guard.NotAllNull(SelectedPhoto) ? Visibility.Collapsed : Visibility.Visible;
			DeleteVisibility = Guard.NotAllNull(SelectedPhoto) ? Visibility.Visible : Visibility.Collapsed;
			_isInitialize = Guard.NotAllNull(SelectedPhoto);
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

		public CategoryEntity? SelectedCategory
		{
			get => _selectedCategory;
			set
			{
				if (SetProperty(ref _selectedCategory, value))
				{
					RoundDataSetCommand.Execute(null);
					ManufacturerDataSetCommand.Execute(null);
				}
			}
		}

		public RoundEntity? SelectedRound
		{
			get => _selectedRound;
			set => SetProperty(ref _selectedRound, value);
		}

		public ManufacturerEntity? SelectedManufacturer
		{
			get => _selectedManufacturer;
			set
			{
				if (SetProperty(ref _selectedManufacturer, value))
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
				if (SetProperty(ref _selectedTeam, value))
				{
					CarDataSetCommand.Execute(null);
				}
			}
		}

		public CarEntity? SelectedCar
		{
			get => _selectedCar;
			set => SetProperty(ref _selectedCar, value);
		}

		public string FilePath
		{
			get => _filePath;
			set => SetProperty(ref _filePath, value);
		}
		public string Description
		{
			get => _description;
			set => SetProperty(ref _description, value);
		}

		public PhotoEntity? SelectedPhoto { get; }
		public Visibility UploadVisibility
		{
			get => _uploadVisibility;
			set => SetProperty(ref _uploadVisibility, value);
		}

		public Visibility DeleteVisibility
		{
			get => _deleteVisibility;
			set => SetProperty(ref _deleteVisibility, value);
		}

		public Visibility ViewVisibility
		{
			get => _viewVisibility;
			set => SetProperty(ref _viewVisibility, value);
		}

		public Visibility ProgressVisibility
		{
			get => _progressVisibility;
			set => SetProperty(ref _progressVisibility, value);
		}
		public bool? DialogResult { get; set; }

		public ICommand RoundDataSetCommand => new DataSetCommand(RoundDataSet);
		public ICommand ManufacturerDataSetCommand => new DataSetCommand(ManufacturerDataSet);
		public ICommand TeamDataSetCommand => new DataSetCommand(TeamDataSet);
		public ICommand CarDataSetCommand => new DataSetCommand(CarDataSet);
		public ICommand OpenFileCommand => new OpenFileCommand(this);

		public async Task InitializeAsync()
		{
			ViewVisibility = Visibility.Collapsed;
			ProgressVisibility = Visibility.Visible;

			FilePath = SelectedPhoto?.FilePath.Value ?? "../Resource/noimage.jpg";
			Description = SelectedPhoto?.Description.Value ?? string.Empty;

			CategoryList = await _categoryRepository.GetCategoriesAsync();
			SelectedCategory = _isInitialize
				? CategoryList.FirstOrDefault(a => a.Name.Value == SelectedPhoto?.Category.Value) ?? CategoryList.FirstOrDefault()
				: CategoryList.FirstOrDefault();

			ViewVisibility = Visibility.Visible;
			ProgressVisibility = Visibility.Collapsed;
		}

		private async Task RoundDataSet()
		{
			RoundList = await _roundRepository.GetRoundsAsync(SelectedCategory?.Id.Value);
			SelectedRound = _isInitialize
				? RoundList.FirstOrDefault(a => a.Name.Value == SelectedPhoto?.Round.Value)
				: RoundList.FirstOrDefault();
		}

		private async Task ManufacturerDataSet()
		{
			ManufacturerList = await _manufacturerRepository.GetManufacturersAsync(SelectedCategory?.Id.Value);
			SelectedManufacturer = _isInitialize
				? ManufacturerList.FirstOrDefault(a => a.Name.Value == SelectedPhoto?.Manufacturer.Value)
				: ManufacturerList.FirstOrDefault();
		}

		private async Task TeamDataSet()
		{
			TeamList = await _teamRepository.GetTeamsAsync(SelectedCategory?.Id.Value, SelectedManufacturer?.Id.Value);
			SelectedTeam = _isInitialize
				? TeamList.FirstOrDefault(a => a.Name.Value == SelectedPhoto?.Team.Value)
				: TeamList.FirstOrDefault();
		}

		private async Task CarDataSet()
		{
			CarList = await _carRepository.GetCarsAsync(SelectedCategory?.Id.Value, SelectedManufacturer?.Id.Value, SelectedTeam?.Id.Value);
			SelectedCar = _isInitialize
				? CarList.FirstOrDefault(a => a.Name.Value == SelectedPhoto?.Car.Value)
				: CarList.FirstOrDefault();
			_isInitialize = false;
		}
	}
}
