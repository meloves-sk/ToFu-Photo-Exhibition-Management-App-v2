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
			_photoViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			var openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "Image files (*.jpg, *.jpeg)|*.jpg;*.jpeg;";
			if (openFileDialog.ShowDialog() == true)
			{
				_photoViewModel.FilePath = openFileDialog.FileName;
			}
		}
	}
}
