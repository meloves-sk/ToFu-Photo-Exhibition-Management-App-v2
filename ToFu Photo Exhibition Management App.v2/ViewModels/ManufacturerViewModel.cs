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
	public class ManufacturerViewModel : ViewModelBase
	{
		private readonly IManufacturerRepository _manufacturerRepository;
		private ImmutableList<ManufacturerEntity> _manufacturerList = ImmutableList<ManufacturerEntity>.Empty;
		private ManufacturerEntity? _selectedManufacturer = null;
		private string _manufacturerName = string.Empty;
		private string _status = "Unselected";
		public ManufacturerViewModel(IDialogCoordinator dialogCoordinator)
		{
			_manufacturerRepository = Factories.CreateManufacturerRepository();
			DialogCoordinator = dialogCoordinator;
		}
		public ImmutableList<ManufacturerEntity> ManufacturerList
		{
			get => _manufacturerList;
			set => SetProperty(ref _manufacturerList, value);
		}

		public ManufacturerEntity? SelectedManufacturer
		{
			get => _selectedManufacturer;
			set => SetProperty(ref _selectedManufacturer, value);
		}
		public string ManufacturerName
		{
			get => _manufacturerName;
			set => SetProperty(ref _manufacturerName, value);
		}
		public string Status
		{
			get => _status;
			set => SetProperty(ref _status, value);
		}
		public IDialogCoordinator DialogCoordinator { get; }
		public bool? DialogResult { get; set; }
		public ICommand ResetCommand => new ResetManufacturerCommand(this);
		public ICommand SaveCommand => new SaveManufacturerCommand(this, _manufacturerRepository);
		public ICommand EditCommand => new EditManufacturerCommand(this);
		public ICommand DeleteCommand => new DeleteManufacturerCommand(this, _manufacturerRepository);
		public async Task InitializeAsync()
		{
			await LoadRoundsAsync();
		}
		public async Task LoadRoundsAsync()
		{
			ManufacturerList = await _manufacturerRepository.GetManufacturersAsync(new Id(0));
		}
	}
}
