using System.Windows;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
namespace ToFuPhotoExhibitionManagementApp.v2.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainView : Window
	{
		private readonly MainViewModel _mainViewModel;
		public MainView()
		{
			InitializeComponent();
			_mainViewModel = (MainViewModel)DataContext;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await _mainViewModel.InitializeAsync();
		}
	}
}