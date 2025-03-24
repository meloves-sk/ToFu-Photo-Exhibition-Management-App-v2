using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
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
	public class RoundViewModel : ViewModelBase
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IRoundRepository _roundRepository;
		private ImmutableList<CategoryEntity> _categoryList = ImmutableList<CategoryEntity>.Empty;
		private ImmutableList<RoundEntity> _roundList = ImmutableList<RoundEntity>.Empty;
		private CategoryEntity? _selectedCategory;
		private RoundEntity? _selectedRound;
		private string _roundName = string.Empty;
		private string _status = "Unselected";
		public RoundViewModel(IDialogCoordinator dialogCoordinator)
		{
			_categoryRepository = Factories.CreateCategoryRepository();
			_roundRepository = Factories.CreateRoundRepository();
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
		public CategoryEntity? SelectedCategory
		{
			get => _selectedCategory;
			set
			{
				SetProperty(ref _selectedCategory, value);
				_ = LoadRoundsAsync();
			}
		}

		public RoundEntity? SelectedRound
		{
			get => _selectedRound;
			set => SetProperty(ref _selectedRound, value);
		}
		public string RoundName
		{
			get => _roundName;
			set => SetProperty(ref _roundName, value);
		}
		public string Status
		{
			get => _status;
			set => SetProperty(ref _status, value);
		}
		public IDialogCoordinator DialogCoordinator { get; }
		public bool? DialogResult { get; set; }
		public ICommand ResetCommand => new ResetRoundCommand(this);
		public ICommand SaveCommand => new SaveRoundCommand(this, _roundRepository);
		public ICommand EditCommand => new EditRoundCommand(this);
		public ICommand DeleteCommand => new DeleteRoundCommand(this, _roundRepository);
		public async Task InitializeAsync()
		{
			CategoryList = await _categoryRepository.GetCategoriesAsync();
			SelectedCategory = CategoryList.FirstOrDefault();
		}
		public async Task LoadRoundsAsync()
		{
			RoundList = await _roundRepository.GetRoundsAsync(SelectedCategory?.Id);
		}
	}
}
