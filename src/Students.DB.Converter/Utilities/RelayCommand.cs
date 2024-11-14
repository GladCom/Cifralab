using System.Windows.Input;

namespace Students.DB.Converter.Utilities;

public class RelayCommand : ICommand
{
  private readonly Action<object?> _execute;
  private readonly Func<object?, bool>? _canExecute;

  public event EventHandler? CanExecuteChanged
  {
    add => CommandManager.RequerySuggested += value;
    remove => CommandManager.RequerySuggested -= value;
  }

  public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
  {
    this._execute = execute;
    this._canExecute = canExecute;
  }

  public bool CanExecute(object? parameter)
  {
    return this._canExecute is null || this._canExecute(parameter);
  }

  public void Execute(object? parameter)
  {
    this._execute(parameter);
  }
}