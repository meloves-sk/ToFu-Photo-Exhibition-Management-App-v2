using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class ResetRoundCommand : ICommand
	{
		private readonly RoundViewModel _roundViewModel;
		public ResetRoundCommand(RoundViewModel roundViewModel)
		{
			_roundViewModel = roundViewModel;
			_roundViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			_roundViewModel.SelectedRound = null;
			_roundViewModel.Status = "Unselected";
			_roundViewModel.RoundName = string.Empty;
		}
	}
}
