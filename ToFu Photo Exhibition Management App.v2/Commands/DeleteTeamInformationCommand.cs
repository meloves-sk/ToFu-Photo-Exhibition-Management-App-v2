using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Entities;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Helper;
using ToFuPhotoExhibitionManagementApp.v2.Domain.Repositories;
using ToFuPhotoExhibitionManagementApp.v2.ViewModels;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
    public class DeleteTeamInformationCommand:ICommand
    {
		private readonly TeamInformationViewModel _teamInformationViewModel;
		private readonly ITeamInformationRepository _teamInformationRepository;
		public DeleteTeamInformationCommand(TeamInformationViewModel teamInformationViewModel, ITeamInformationRepository teamInformationRepository)
		{
			_teamInformationViewModel = teamInformationViewModel;
			_teamInformationRepository = teamInformationRepository;
			_teamInformationViewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			if (parameter is TeamInformationEntity selectedTeamInformation)
			{
				Guard.IsNull(selectedTeamInformation, "チーム情報が選択されていません");
				var message = await _teamInformationRepository.DeleteTeamInformationAsync(selectedTeamInformation.Id);
				await _teamInformationViewModel.LoadTeamInformationsAsync();
				_teamInformationViewModel.ResetCommand.Execute(null);
				await _teamInformationViewModel.DialogCoordinator.ShowMessageAsync(_teamInformationViewModel, "成功", message);
				_teamInformationViewModel.DialogResult = true;
			}
		}
	}
}
