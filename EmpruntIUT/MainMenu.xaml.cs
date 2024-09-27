using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpruntIUT.Resources.Components;

namespace EmpruntIUT;

public partial class MainMenu : ContentPage
{
    public MainMenu()
    {
        InitializeComponent();
        BindingContext = this;
    }
}