using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace ToFuPhotoExhibitionManagementApp.v2
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Application.Current.DispatcherUnhandledException += OnDispatcherUnhandledException;

		}
		private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			var activeWindow = Current.Windows.OfType<MetroWindow>().Single(a=> a.IsActive);
			var message = e.Exception.InnerException != null ? e.Exception.InnerException.Message : e.Exception.Message;
			activeWindow.ShowMessageAsync("エラー", message);
			e.Handled = true;
		}
	}

}
