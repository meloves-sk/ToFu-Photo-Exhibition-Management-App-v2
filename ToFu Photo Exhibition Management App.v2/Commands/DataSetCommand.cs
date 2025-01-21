using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ToFuPhotoExhibitionManagementApp.v2.Commands
{
	public class DataSetCommand : ICommand
	{
		private readonly Func<Task> _execute;
		private readonly Func<object?[], bool>? _canExecute;
		public DataSetCommand(Func<Task> execute, Func<object?[], bool>? canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return CanExecute(new object?[] { parameter });
		}

		public bool CanExecute(params object?[] parameters)
		{
			return _canExecute == null || _canExecute(parameters);
		}

		public async void Execute(object? parameter)
		{
			await _execute();
		}
	}
}
