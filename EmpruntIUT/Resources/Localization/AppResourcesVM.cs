using System.ComponentModel;

namespace EmpruntIUT.Resources.Localization;

public class AppResourcesVM : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
    public System.Globalization.CultureInfo Culture
    {
        get => AppResources.Culture;
        set
        {
            if (AppResources.Culture == value) return;
            AppResources.Culture = value;
            OnPropertyChanged("Culture");
            OnPropertyChanged("Hello");
            OnPropertyChanged("Welcome");
            OnPropertyChanged("Button");
            OnPropertyChanged("SelectTheme");
        }
    }
    
    public string Hello => AppResources.Hello;
    public string Welcom => AppResources.Welcom;
    public string Button => AppResources.Button;
    public string SelectTheme => AppResources.SelectTheme;
}