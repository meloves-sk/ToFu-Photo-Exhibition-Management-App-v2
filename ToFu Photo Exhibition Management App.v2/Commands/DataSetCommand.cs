using System.Windows.Input;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	internal class DataSetCommand : ICommand
	{
		private readonly Func<Task> _execute;
		public DataSetCommand(Func<Task> execute)
		{
			_execute = execute;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public async void Execute(object? parameter)
		{
			await _execute();
		}
	}
}
