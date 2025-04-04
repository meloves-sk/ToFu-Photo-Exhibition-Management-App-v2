﻿using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
using ToFuPhotoExhibitionManagementApp.v2.Views;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class ShowPhotoViewCommand : ICommand
	{
		private readonly MainViewModel _mainViewModel;
		public ShowPhotoViewCommand(MainViewModel mainViewModel)
		{
			_mainViewModel = mainViewModel;
			_mainViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			var photoView = new PhotoView(_mainViewModel.SelectedPhoto);
			if (photoView.ShowDialog() == true)
			{
				await _mainViewModel.LoadPhotosAsync();
			}
			_mainViewModel.SelectedPhoto = null;
		}
	}
}
