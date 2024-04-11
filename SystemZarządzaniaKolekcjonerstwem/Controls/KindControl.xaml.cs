namespace SystemZarządzaniaKolekcjonerstwem.Controls;

public partial class KindControl : ContentView
{

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(KindControl), string.Empty);
    public static readonly BindableProperty AppearsProperty = BindableProperty.Create(nameof(Appears), typeof(int), typeof(KindControl), 0);
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public int Appears
    {
        get => (int)GetValue(AppearsProperty);
        set => SetValue(AppearsProperty, value);
    }

    public KindControl()
	{
        InitializeComponent();
    }
}
