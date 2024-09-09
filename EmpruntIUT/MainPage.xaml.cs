using EmpruntIUT.Resources.Themes;

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

        ResourceDictionary chosenTheme = chosenThemeString switch 
        {
            "Light" => new LightTheme(),
            "Dark" => new DarkTheme(),
            "Color Blind" => new ColorBlindTheme(),
            "Odin" => new OdinTheme(),
            _ => new LightTheme()
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
    }
}