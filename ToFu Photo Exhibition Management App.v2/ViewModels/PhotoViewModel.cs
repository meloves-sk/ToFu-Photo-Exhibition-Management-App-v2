using MahApps.Metro.Controls.Dialogs;
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

		private string _title;
		private string _filePath;
		private string _description = string.Empty;

		private Visibility _uploadVisibility = Visibility.Visible;
		private Visibility _deleteVisibility = Visibility.Collapsed;

		private bool isInitialize;

		public PhotoViewModel(IDialogCoordinator dialogCoordinator, PhotoEntity? selectedPhoto = null)
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_roundRepository = Factories.CreateRoundRepository();
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			_teamRepository = Factories.CreateTeamRepository();
			_carRepository = Factories.CreateCarRepository();
			_photoRepository = Factories.CreatePhotoRepository();
			SelectedPhoto = selectedPhoto;
			_title = SelectedPhoto != null ? "Edit Photo" : "Add Photo";
			_filePath = SelectedPhoto?.FilePath.Value ?? "../Resource/noimage.jpg";
			_description = SelectedPhoto?.Description.Value ?? string.Empty;
			UploadVisibility = SelectedPhoto == null ? Visibility.Visible : Visibility.Collapsed;
			DeleteVisibility = SelectedPhoto == null ? Visibility.Collapsed : Visibility.Visible;
			isInitialize = SelectedPhoto != null;
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
			set => SetProperty(ref _selectedRound, value);
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
			set => SetProperty(ref _selectedCar, value);
		}

		public string Title
		{
			get => _title;
			set => SetProperty(ref _title, value);
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

		public IDialogCoordinator DialogCoordinator { get; }
		public bool? DialogResult { get; set; }

		public ICommand OpenFileCommand => new OpenFileCommand(this);
		public ICommand SaveCommand => new SavePhotoCommand(this, _photoRepository);
		public ICommand DeleteCommand => new DeletePhotoCommand(this, _photoRepository);

		public async Task InitializeAsync()
		{
			CategoryList = await _categoryRepository.GetCategoriesAsync();
			SelectedCategory = isInitialize
				? CategoryList.First(a => a.Name == new Name(SelectedPhoto!.Category.Value))
				: CategoryList.First();
		}

		private async Task LoadRoundsAsync()
		{
			RoundList = await _roundRepository.GetRoundsAsync(SelectedCategory?.Id);
			SelectedRound = isInitialize
				? RoundList.FirstOrDefault(a => a.Name == new Name(SelectedPhoto!.Round.Value))
				: RoundList.FirstOrDefault();
		}

		private async Task LoadManufacturersAsync()
		{
			ManufacturerList = await _manufacturerRepository.GetManufacturersAsync(SelectedCategory?.Id);
			SelectedManufacturer = isInitialize
				? ManufacturerList.FirstOrDefault(a => a.Name == new Name(SelectedPhoto!.Manufacturer.Value))
				: ManufacturerList.FirstOrDefault();
		}

		private async Task LoadTeamsAsync()
		{
			TeamList = await _teamRepository.GetTeamsAsync(SelectedCategory?.Id, SelectedManufacturer?.Id);
			SelectedTeam = isInitialize
				? TeamList.FirstOrDefault(a => a.Name == new Name(SelectedPhoto!.Team.Value))
				: TeamList.FirstOrDefault();
		}

		private async Task LoadCarsAsync()
		{
			CarList = await _carRepository.GetCarsAsync(SelectedCategory?.Id, SelectedManufacturer?.Id, SelectedTeam?.Id);
			SelectedCar = isInitialize
				? CarList.FirstOrDefault(a => a.Name == new Name(SelectedPhoto!.Car.Value))
				: CarList.FirstOrDefault();
			isInitialize = false;
		}
	}
}
