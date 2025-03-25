using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Domain.ValueObjects;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Commands;

namespace ToFuPhotoExhibitionManagementApp.v2.ViewModels
{
	public class CarViewModel : ViewModelBase
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IManufacturerRepository _manufacturerRepository;
		private readonly ITeamInformationRepository _teamInformationRepository;
		private readonly ICarRepository _carRepository;
		private ImmutableList<CategoryEntity> _categoryList = ImmutableList<CategoryEntity>.Empty;
		private ImmutableList<ManufacturerEntity> _manufacturerList = ImmutableList<ManufacturerEntity>.Empty;
		private ImmutableList<TeamInformationEntity> _teamInformationList = ImmutableList<TeamInformationEntity>.Empty;
		private ImmutableList<CarEntity> _carList = ImmutableList<CarEntity>.Empty;
		private CategoryEntity? _selectedCategory = null;
		private ManufacturerEntity? _selectedManufacturer = null;
		private TeamInformationEntity? _selectedTeamInformation = null;
		private CarEntity? _selectedCar = null;
		private string _carName = string.Empty;
		private int? _carNo = null;
		private string _status = "Unselected";
		public CarViewModel(IDialogCoordinator dialogCoordinator)
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			_teamInformationRepository = Factories.CreateTeamInformationRepository();
			_carRepository = Factories.CreateCarRepository();
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

		public ImmutableList<TeamInformationEntity> TeamInformationList
		{
			get => _teamInformationList;
			set => SetProperty(ref _teamInformationList, value);
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
				_ = LoadManufacturersAsync();
			}
		}

		public ManufacturerEntity? SelectedManufacturer
		{
			get => _selectedManufacturer;
			set
			{
				SetProperty(ref _selectedManufacturer, value);
				_ = LoadTeamInformationsAsync();
				_ = LoadCarsAsync();
			}
		}

		public TeamInformationEntity? SelectedTeamInformation
		{
			get => _selectedTeamInformation;
			set => SetProperty(ref _selectedTeamInformation, value);
		}

		public CarEntity? SelectedCar
		{
			get => _selectedCar;
			set => SetProperty(ref _selectedCar, value);
		}
		public string CarName
		{
			get => _carName;
			set => SetProperty(ref _carName, value);
		}
		public int? CarNo
		{
			get => _carNo;
			set => SetProperty(ref _carNo, value);
		}
		public string Status
		{
			get => _status;
			set => SetProperty(ref _status, value);
		}
		public IDialogCoordinator DialogCoordinator { get; }
		public bool? DialogResult { get; set; }
		public ICommand ResetCommand => new ResetCarCommand(this);
		public ICommand SaveCommand => new SaveCarCommand(this, _carRepository);
		public ICommand EditCommand => new EditCarCommand(this);
		public ICommand DeleteCommand => new DeleteCarCommand(this, _carRepository);
		public async Task InitializeAsync()
		{
			CategoryList = await _categoryRepository.GetCategoriesAsync();
			SelectedCategory = CategoryList.FirstOrDefault();
		}
		public async Task LoadManufacturersAsync()
		{
			ManufacturerList = await _manufacturerRepository.GetManufacturersAsync(SelectedCategory?.Id);
			SelectedManufacturer = ManufacturerList.FirstOrDefault();
		}
		public async Task LoadTeamInformationsAsync()
		{
			TeamInformationList = await _teamInformationRepository.GetTeamInformationsAsync(SelectedCategory?.Id, SelectedManufacturer?.Id);
			SelectedTeamInformation = TeamInformationList.FirstOrDefault();
		}
		public async Task LoadCarsAsync()
		{
			CarList = await _carRepository.GetCarsAsync(SelectedCategory?.Id, SelectedManufacturer?.Id, new Id(0));
		}
	}
}
