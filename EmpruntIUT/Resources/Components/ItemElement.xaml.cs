using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpruntIUT.Resources.Components;

public partial class ItemElement : ContentView
{
    public ItemElement()
    {
        InitializeComponent();
    }
    
    public static readonly BindableProperty ImageNameProperty =
        BindableProperty.Create("ImageName", typeof(string), typeof(ItemElement), "");
	
    public string ImageName
    {
        get => (string)GetValue(ImageNameProperty);
        set => SetValue(ImageNameProperty, value);
    }

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create("Title", typeof(string), typeof(ItemElement), "No Title");
	
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty SubTitleProperty =
        BindableProperty.Create("SubTitle", typeof(string), typeof(ItemElement), "Lorem Ipsum Dolor");
	
    public string SubTitle
    {
        get => (string)GetValue(SubTitleProperty);
        set => SetValue(SubTitleProperty, value);
    }

    public static readonly BindableProperty ColorProperty =
        BindableProperty.Create("Color", typeof(Color), typeof(ItemElement), Colors.Gray);
	
    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }
}