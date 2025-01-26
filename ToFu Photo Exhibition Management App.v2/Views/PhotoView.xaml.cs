using System.Windows;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Views
{
	/// <summary>
	/// PhotoView.xaml の相互作用ロジック
	/// </summary>
	public partial class PhotoView : Window
	{
		private readonly PhotoViewModel _photoViewModel;
		public PhotoView(PhotoEntity? selectedPhoto = null)
		{
			InitializeComponent();
			_photoViewModel = new PhotoViewModel(selectedPhoto);
			DataContext = _photoViewModel;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await _photoViewModel.InitializeAsync();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult = _photoViewModel.DialogResult;
		}
	}
}
