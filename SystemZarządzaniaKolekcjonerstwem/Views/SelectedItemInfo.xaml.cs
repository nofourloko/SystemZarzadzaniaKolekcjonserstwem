namespace SystemZarządzaniaKolekcjonerstwem.Views;

using System.Collections.ObjectModel;
using SystemZarządzaniaKolekcjonerstwem.Models;

public partial class SelectedItemInfo : ContentPage
{
	public UserCollection selectedItem { get; set; }
    public UserCollectionListHandler collectionHandler { get; set; }
    public ObservableCollection<UserCollection> selectedCollectionList { get; set; }
    public SelectedItemInfo(UserCollection item, UserCollectionListHandler userCollectionListHandler, ObservableCollection<UserCollection> selectedCollcetion)
	{
		InitializeComponent();
        collectionHandler = userCollectionListHandler;
        selectedCollectionList = selectedCollcetion;
        selectedItem = item;

        if(item.AdditionalName == "")
        {
            additionalField.IsVisible = false;
        }

		BindingContext = this;
    }

    async void Change_Clicked(System.Object sender, System.EventArgs e)
    {
        if(editorTitle.Text != "" || editorTitle.Text != null)
        {
            selectedItem.Title = editorTitle.Text;
        }

        if(editorStatus.Text != "" || editorStatus.Text != null)
        {
            selectedItem.Status = editorStatus.Text;
            int oIndex = selectedCollectionList.IndexOf(selectedItem);
            int nIndex = 0;

            if (editorStatus.Text == "Sprzedany")
            {
                nIndex = selectedCollectionList.Count() - 1;
            }

            if(oIndex != nIndex)
            {
                selectedCollectionList.Move(oIndex, nIndex);
            }
            
        }

        if(editorPrice.Text != "" || editorPrice.Text != null)
        {
            if(Int32.TryParse(editorPrice.Text, out int p))
            {
                selectedItem.Price = p;
            }
        }

        if (editorRate.Text != "" || editorRate.Text != null)
        {
            if (Int32.TryParse(editorRate.Text, out int r))
            {
                selectedItem.Rate = r;
            }
        }

        if (editorAdditionalValue.Text != "" || editorAdditionalValue.Text != null)
        {
            selectedItem.AdditionalValue = editorAdditionalValue.Text;
        }

        collectionHandler.ChangeItem();
        await Navigation.PopAsync();
    }

   
}


