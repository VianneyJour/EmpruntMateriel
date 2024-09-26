using System.Windows.Input;

namespace MyToolKit;

public class RelayCommand<T> : ICommand
{
    public bool CanExecute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object? parameter)
    {
        throw new NotImplementedException();
    }

    public event EventHandler? CanExecuteChanged;
}