namespace SystemZarządzaniaKolekcjonerstwem.Views;

using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.VisualBasic;
using SystemZarządzaniaKolekcjonerstwem.Models;
using SystemZarządzaniaKolekcjonerstwem.Utils;

public partial class SelectedKindList : ContentPage
{
	public ObservableCollection<UserCollection> selectedCollectionList { get; set; }
	public UserCollectionListHandler userCollectionHandler { get; set; }
	public bool warning { get; set; } = false;
    public string columnName { get; set; } = "";
    public string Kind { get; set; }

    public SelectedKindList(UserCollectionListHandler Handler, string selectedKind)
	{
		InitializeComponent();
        userCollectionHandler = Handler;
        Kind = selectedKind;

        selectedCollectionList = new ObservableCollection<UserCollection>(
            userCollectionHandler.userCollectionList.Where(item => item.Kind == Kind && item.Title != "").OrderBy(item => item.Status).ToList()
        );

        if (selectedCollectionList.Count() > 0)
        {
            if (selectedCollectionList[0].AdditionalName != "")
            {
                columnName = selectedCollectionList[0].AdditionalName;
            }
            else
            {
                gridNewColumn.IsVisible = false;
            }
        }
        else
        {
            gridNewColumn.IsVisible = false;
        }

        var collectionHasExtraCol = userCollectionHandler.userCollectionList.Where(item => item.Kind == Kind && item.Title == "").FirstOrDefault();

        if (collectionHasExtraCol.AdditionalName != "")
        {
            columnName = collectionHasExtraCol.AdditionalName;
            gridNewColumn.IsVisible = false;
        }


        BindingContext = this;
	}


    async void AddNewCollectionItem(System.Object sender, System.EventArgs e)
    {
		string title = editorTitle.Text;
		string status = editorStatus.Text;
		string price = editorPrice.Text;
		string rate = editorRate.Text;
		

		bool result = FormHandling.newItemFormHandler(title, price, status,rate);
		

        if (result == false)
		{
			return;
		}


		UserCollection item = new UserCollection
		{
			Kind = Kind,
			Title = title,
			Status = status,
			Price = Int32.Parse(price),
			Rate = Int32.Parse(rate),
            AdditionalName = columnName,
            AdditionalValue = "",
        };

        if (selectedCollectionList.Where(el => el.Title == item.Title).FirstOrDefault() != null)
        {
            bool answer = await Shell.Current.DisplayAlert("Alert", "Item already in collection, are you sure you want to add it", "Yes", "No");

            if(answer == false)
            {
                return;
            }
        }

        userCollectionHandler.AddNewItem(item);

        if(selectedCollectionList.Count() < 1 && columnName == "")
        {
            gridNewColumn.IsVisible = true;
        }

		if(status != "Sprzedany")
		{
			selectedCollectionList.Insert(0, item);
		}
		else
		{
            selectedCollectionList.Add(item);
        }
		

        FormHandling.newItemFormCleaner(editorTitle, editorStatus, editorPrice, editorRate);
    }

    void DeleteItemFromCollection(System.Object sender, System.EventArgs e)
    {
		UserCollection item = (UserCollection)((Button)sender).BindingContext;
        string tmp = "";

        if (selectedCollectionList.Count() - 1 < 1)
        {
            if(columnName != "")
            {
                gridNewColumn.IsVisible = false;
                tmp = columnName;
            }
            else
            {
                gridNewColumn.IsVisible = true;
            }
        }
        userCollectionHandler.DeleteItem(item, tmp);
		selectedCollectionList.Remove(item);

        
    }

    void ListView_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
		if(collectionItemsListView.SelectedItem != null)
		{
			UserCollection selectedItem = (UserCollection)e.SelectedItem;
			Navigation.PushAsync(new SelectedItemInfo(selectedItem, userCollectionHandler, selectedCollectionList));
		}

		collectionItemsListView.SelectedItem = null;
    }

    void GenerateSummaryPage(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new CollectionSummaryPage(selectedCollectionList));
    }

    void AddNewColumn(System.Object sender, System.EventArgs e)
    {
        if(editorColumn.Text == "" || editorColumn.Text == null)
        {
            return;
        }

        columnName = editorColumn.Text;

        foreach(var item in selectedCollectionList)
        {
            item.AdditionalName = columnName;
        }
        gridNewColumn.IsVisible = false;

        userCollectionHandler.NewCollectionColumnAdd(Kind, columnName);
    }
}
