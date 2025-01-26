using Microsoft.Win32;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	internal class OpenFileCommand : ICommand
	{
		private readonly PhotoViewModel _photoViewModel;
		public OpenFileCommand(PhotoViewModel photoViewModel)
		{
			_photoViewModel = photoViewModel;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png;";
			if (openFileDialog.ShowDialog() == true)
			{
				_photoViewModel.FilePath = openFileDialog.FileName;
			}
		}
	}
}
