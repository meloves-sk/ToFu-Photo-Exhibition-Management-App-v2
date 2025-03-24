using System.Windows;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.Infrastructure.WebAPI;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
using ToFuPhotoExhibitionManagementApp.v2.Views;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class DeletePhotoCommand : ICommand
	{
		private readonly PhotoViewModel _photoViewModel;
		private readonly IPhotoRepository _photoRepository;
		public DeletePhotoCommand(PhotoViewModel photoViewModel, IPhotoRepository photoRepository)
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
				Guard.IsNull(_photoViewModel.SelectedPhoto, "写真が選択されていません");
				var message = await _photoRepository.DeletePhotoAsync(_photoViewModel.SelectedPhoto!.Id);
				await _photoViewModel.DialogCoordinator.ShowMessageAsync(_photoViewModel, "成功", message);
				_photoViewModel.DialogResult = true;
				photoView.Close();
			}
		}
	}
}
