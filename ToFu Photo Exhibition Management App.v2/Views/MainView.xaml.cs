﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;
namespace ToFuPhotoExhibitionManagementApp.v2.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainView : MetroWindow
	{
		private readonly MainViewModel _mainViewModel;
		public MainView()
		{
			InitializeComponent();
			_mainViewModel = new MainViewModel(DialogCoordinator.Instance);
			DataContext = _mainViewModel;
		}

		private async void Window_Loaded(object sender, RoutedEventArgs e)
		{
			await _mainViewModel.InitializeAsync();
		}
	}
}