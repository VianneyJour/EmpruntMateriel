using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyToolKit;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetProperty<T>(ref T member, T newValue, [CallerMemberName]string propertyName = "")
    {
        if(EqualityComparer<T>.Default.Equals(member, newValue))
            return false;
        member = newValue;
        OnPropertyChanged(propertyName);
        return true;
    }
	
    protected bool SetProperty<T>(T member, T newValue, Action<T> action, [CallerMemberName]string propertyName = "")
    {
        if(EqualityComparer<T>.Default.Equals(member, newValue))
            return false;
        action(newValue);
        OnPropertyChanged(propertyName);
        return true;
    }
}