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
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Views
{
    /// <summary>
    /// TeamView.xaml の相互作用ロジック
    /// </summary>
    public partial class TeamView : MetroWindow
    {
        private readonly TeamViewModel _teamViewModel;
        public TeamView()
        {
            InitializeComponent();
			_teamViewModel = new TeamViewModel(DialogCoordinator.Instance);
			DataContext = _teamViewModel;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
            await _teamViewModel.InitializeAsync();
        }

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            DialogResult = _teamViewModel.DialogResult;
        }
    }
}
