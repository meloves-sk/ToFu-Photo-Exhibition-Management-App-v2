﻿using System.Windows;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
using ToFuPhotoExhibitionManagementApp.v2.Views;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	internal class SavePhotoCommand : ICommand
	{
		private readonly PhotoViewModel _photoViewModel;
		private readonly IPhotoRepository _photoRepository;
		public SavePhotoCommand(PhotoViewModel photoViewModel, IPhotoRepository photoRepository)
		{
			_photoViewModel = photoViewModel;
			_photoRepository = photoRepository;
			_photoViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return parameter is PhotoView;
		}

		public async void Execute(object? parameter)
		{
			if (parameter is PhotoView photoView)
			{
				Guard.IsFail(!_photoViewModel.FilePath.EndsWith("noimage.jpg"), "写真を選択してください");
				Guard.IsNull(_photoViewModel.SelectedRound, "ラウンドを選択してください");
				Guard.IsNull(_photoViewModel.SelectedCar, "車両を選択してください");
				var message = await _photoRepository.SavePhotoAsync(_photoViewModel.SelectedPhoto?.Id, _photoViewModel.Description, _photoViewModel.SelectedRound!.Id, _photoViewModel.SelectedCar!.Id, _photoViewModel.FilePath);
				await _photoViewModel.DialogCoordinator.ShowMessageAsync(_photoViewModel, "成功", message);
				_photoViewModel.DialogResult = true;
				photoView.Close();
			}
		}
	}
}
