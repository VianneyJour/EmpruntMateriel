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
            OnPropertyChanged("Connect");
            OnPropertyChanged("EnterEmail");
            OnPropertyChanged("EnterPassword");
        }
    }
    
    public string Hello => AppResources.Hello;
    public string Welcom => AppResources.Welcom;
    public string Button => AppResources.Button;
    public string SelectTheme => AppResources.SelectTheme;
    public string Connect => AppResources.Connect;
    public string EnterEmail => AppResources.EnterEmail;
    public string EnterPassword => AppResources.EnterPassword;
}