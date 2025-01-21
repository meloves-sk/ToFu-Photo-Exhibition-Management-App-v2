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
			var message = e.Exception.InnerException != null ? e.Exception.InnerException.Message : e.Exception.Message;
			MessageBox.Show("異常を検知しました\n" +
				"-- エラー内容 --\n" +
				message,
				"ToFu Photo Exhibition Management App");
		}
	}

}
