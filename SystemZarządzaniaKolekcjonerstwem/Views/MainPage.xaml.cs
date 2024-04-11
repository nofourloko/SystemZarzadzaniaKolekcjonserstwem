namespace SystemZarządzaniaKolekcjonerstwem.Views;
using SystemZarządzaniaKolekcjonerstwem.Models;
using SystemZarządzaniaKolekcjonerstwem.Utils;

public partial class MainPage : ContentPage
{
	public UserCollectionListHandler userCollectionHandler { get; set; } = new UserCollectionListHandler();
    public MainPage()
	{
        InitializeComponent();
        BindingContext = this;
    }

    void SelectedCollection(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        if(CollectionKidsList.SelectedItem != null)
        {
            CollectionKinds selectedKind = (CollectionKinds)e.SelectedItem;

            Navigation.PushAsync(new SelectedKindList(userCollectionHandler, selectedKind.Kind));
        }

        CollectionKidsList.SelectedItem = null;
    }

    void Button_Add_Kind(System.Object sender, System.EventArgs e)
    {
        string kind = collectionKindEditor.Text;

        if (FormHandling.kindFormHandler(kind))
        {
            UserCollection collection = new UserCollection
            {
                Kind = kind,
                Title = "",
                Price = 0,
                Status = "",
                Rate = 0,
                AdditionalName = "",
                AdditionalValue = ""
            };
            
            userCollectionHandler.AddNewCollection(collection);
            collectionKindEditor.Text = "";
        }
    }

    void Button_DeleteCollection(System.Object sender, System.EventArgs e)
    {
        CollectionKinds userCollection = (CollectionKinds)((Button)sender).BindingContext;
        userCollectionHandler.DeleteItemCollectionKinds(userCollection);
    }
}
