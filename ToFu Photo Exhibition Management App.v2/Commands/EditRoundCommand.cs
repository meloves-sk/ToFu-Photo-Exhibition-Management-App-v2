using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class EditRoundCommand : ICommand
	{
		private readonly RoundViewModel _roundViewModel;
		public EditRoundCommand(RoundViewModel roundViewModel)
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
			if (parameter is RoundEntity selectedRound)
			{
				_roundViewModel.SelectedRound = selectedRound;
				_roundViewModel.Status = $"Selected: {selectedRound.Name.Value}";
				_roundViewModel.RoundName = selectedRound.Name.Value;
			}
		}
	}
}
