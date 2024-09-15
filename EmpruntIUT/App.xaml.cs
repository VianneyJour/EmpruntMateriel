using EmpruntIUT.Resources.Themes;
using EmpruntIUT.Resources.Styles;

namespace EmpruntIUT;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();

        string themeSelected = Preferences.Default.Get("Theme", "Dark");
        switch(themeSelected)
        {
            case "Dark" :
                Resources.MergedDictionaries.Add(new DarkTheme());
                break;
            case "Light" :
                Resources.MergedDictionaries.Add(new LightTheme());
                break;
            case "Color Blind" :
                Resources.MergedDictionaries.Add(new ColorBlindTheme());
                break;
            case "Odin" :
                Resources.MergedDictionaries.Add(new OdinTheme());
                break;
            case "System" :
                if (Application.Current.RequestedTheme == AppTheme.Light)
                    Resources.MergedDictionaries.Add(new LightTheme());
                else
                {
                    Resources.MergedDictionaries.Add(new DarkTheme());
                }
                break;
            default :
                Resources.MergedDictionaries.Add(new DarkTheme());
                break;
        };
        
        string fontSizeSelected = Preferences.Default.Get("FontSize", "Small");
        switch(fontSizeSelected)
        {
            case "Small" :
                Resources.MergedDictionaries.Add(new SmallFont());
                break;
            case "Medium" :
                Resources.MergedDictionaries.Add(new MediumFont());
                break;
            case "Big" :
                Resources.MergedDictionaries.Add(new BigFont());
                break;
            default :
                Resources.MergedDictionaries.Add(new SmallFont());
                break;
        };
    }
}