using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class DeleteManufacturerCommand : ICommand
	{
		private readonly ManufacturerViewModel _manufacturerViewModel;
		private readonly IManufacturerRepository _manufacturerRepository;
		public DeleteManufacturerCommand(ManufacturerViewModel manufacturerViewModel, IManufacturerRepository manufacturerRepository)
		{
			_manufacturerViewModel = manufacturerViewModel;
			_manufacturerRepository = manufacturerRepository;
			_manufacturerViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			if (parameter is ManufacturerEntity selectedManufacturer)
			{
				Guard.IsNull(selectedManufacturer, "メーカーが選択されていません");
				var message = await _manufacturerRepository.DeleteManufacturerAsync(selectedManufacturer.Id);
				await _manufacturerViewModel.LoadRoundsAsync();
				_manufacturerViewModel.ResetCommand.Execute(null);
				await _manufacturerViewModel.DialogCoordinator.ShowMessageAsync(_manufacturerViewModel, "成功", message);
				_manufacturerViewModel.DialogResult = true;
			}
		}
	}
}
