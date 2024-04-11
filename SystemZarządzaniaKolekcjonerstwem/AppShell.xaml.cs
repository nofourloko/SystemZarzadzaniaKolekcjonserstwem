namespace SystemZarządzaniaKolekcjonerstwem;
using SystemZarządzaniaKolekcjonerstwem.Views;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(SelectedKindList), typeof(SelectedKindList));
		Routing.RegisterRoute(nameof(SelectedItemInfo), typeof(SelectedItemInfo));
		Routing.RegisterRoute(nameof(CollectionSummaryPage), typeof(CollectionSummaryPage));
	}
}

