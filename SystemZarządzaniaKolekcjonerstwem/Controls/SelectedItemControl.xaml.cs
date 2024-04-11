

namespace SystemZarządzaniaKolekcjonerstwem.Controls;

public partial class SelectedItemControl : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(SelectedItemControl), string.Empty);
    public static readonly BindableProperty StatusProperty = BindableProperty.Create(nameof(Status), typeof(string), typeof(SelectedItemControl), string.Empty);
    public static readonly BindableProperty RateProperty = BindableProperty.Create(nameof(Rate), typeof(int), typeof(SelectedItemControl), 0);
    public static readonly BindableProperty PriceProperty = BindableProperty.Create(nameof(Price), typeof(int), typeof(SelectedItemControl), 0);
    public static readonly BindableProperty AdditionalNameProperty = BindableProperty.Create(nameof(AdditionalName), typeof(string), typeof(SelectedItemControl), string.Empty);
    public static readonly BindableProperty AdditionalValueProperty = BindableProperty.Create(nameof(AdditionalValue), typeof(string), typeof(SelectedItemControl), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Status
    {
        get => (string)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
        
    }

    public int Rate
    {
        get => (int)GetValue(RateProperty);
        set => SetValue(RateProperty, value);
    }

    public int Price
    {
        get => (int)GetValue(PriceProperty);
        set => SetValue(PriceProperty, value);
    }

    public string AdditionalName
    {
        get => (string)GetValue(AdditionalNameProperty);
        set => SetValue(AdditionalNameProperty, value);
    }

    public string AdditionalValue
    {
        get => (string)GetValue(AdditionalValueProperty);
        set => SetValue(AdditionalValueProperty, value);
    }




    public SelectedItemControl()
	{
        InitializeComponent();
	}
}
