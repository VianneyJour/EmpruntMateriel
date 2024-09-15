using EmpruntIUT.Resources.Themes;
using EmpruntIUT.Resources.Styles;

namespace EmpruntIUT;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
    
    void picker_SelectedTheme(object source, EventArgs args)
    {
        string? chosenThemeString = PickerTheme.SelectedItem as string;
        AppTheme currentTheme = Application.Current.RequestedTheme;

        ResourceDictionary chosenTheme = chosenThemeString switch 
        {
            "Dark" => new DarkTheme(),
            "Light" => new LightTheme(),
            "Color Blind" => new ColorBlindTheme(),
            "Odin" => new OdinTheme(),
            "System" => currentTheme == AppTheme.Dark ? new DarkTheme() : new LightTheme(),
            _ => new DarkTheme()
        };
        
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            foreach(var dico in mergedDictionaries.Where(d => d is ICustomTheme).ToList())
            {
                mergedDictionaries.Remove(dico);
            }
            mergedDictionaries.Add(chosenTheme);
        }
        
        Preferences.Default.Set("Theme", chosenThemeString);
    }
    
    void picker_SelectedFontSize(object source, EventArgs args)
    {
        string? chosenFontSizeString = PickerFontSize.SelectedItem as string;

        ResourceDictionary chosenFontSize = chosenFontSizeString switch 
        {
            "Small" => new SmallFont(),
            "Medium" => new MediumFont(),
            "Big" => new BigFont(),
            _ => new SmallFont()
        };
        
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            foreach(var dico in mergedDictionaries.Where(d => d is ICustomFontSize).ToList())
            {
                mergedDictionaries.Remove(dico);
            }
            mergedDictionaries.Add(chosenFontSize);
        }
        
        Preferences.Default.Set("FontSize", chosenFontSizeString);
    }
}