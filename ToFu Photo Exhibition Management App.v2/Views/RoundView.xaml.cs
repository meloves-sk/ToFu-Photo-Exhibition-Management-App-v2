using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Views
{
	/// <summary>
	/// RoundView.xaml の相互作用ロジック
	/// </summary>
	public partial class RoundView : MetroWindow
	{
		private readonly RoundViewModel _roundViewModel;
		public RoundView()
		{
			InitializeComponent();
			_roundViewModel = new RoundViewModel(DialogCoordinator.Instance);
			DataContext = _roundViewModel;
		}

		private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
		{
			await _roundViewModel.InitializeAsync();
		}

		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult = _roundViewModel.DialogResult;
		}
	}
}
