using System.Collections.ObjectModel;
using SystemZarządzaniaKolekcjonerstwem.Models;

namespace SystemZarządzaniaKolekcjonerstwem.Views;

public partial class CollectionSummaryPage : ContentPage
{
	public Summary summary { get; set; }
	public CollectionSummaryPage(ObservableCollection<UserCollection> selectedCollectionList)
	{
		InitializeComponent();
		int soldItems = selectedCollectionList.Where(item => item.Status == "Sprzedany").ToList().Count;
        int wantToSellItems = selectedCollectionList.Where(item => item.Status == "Na sprzedaż").ToList().Count;
		int allItems = selectedCollectionList.Count();

		summary = new Summary
		{
			ItemsAmount = allItems,
			SoldItems = soldItems,
			WantToSellItems = wantToSellItems
		};



		var animation = new Animation
		{
			
			{ 0, 1, new Animation (v => summaryGrid.Scale = v, 1, 2) },
            {0, 1 , new Animation(v => summaryGrid.Opacity = v) }

        };

		summaryGrid.Animate("generating", animation, length: 1500);
        BindingContext = this;
    }
}
