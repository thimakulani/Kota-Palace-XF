using Kota_Palace.Models;
using Plugin.CloudFirestore;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kota_Palace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopDetailedPage : ContentPage
    {
        private readonly string id;
        private ObservableCollection<MenuModel> menuModels = new ObservableCollection<MenuModel>();
        public ObservableCollection<MenuModel> MenuModels { get { return menuModels; } }

        public ShopDetailedPage(string id)
        {
            this.id = id;
            InitializeComponent();
            MenuCollection.ItemsSource = MenuModels;
            //ImageUrl

            CrossCloudFirestore
                .Current
                .Instance
                .Collection("Admins")
                .Document(id)
                .AddSnapshotListener((snapshot, errors) =>
                {
                    if (snapshot.Exists)
                    {
                        var data = snapshot.ToObject<ShopModel>();
                        ImgIcon.Source = data.ImgUrl;
                    }
                });

            LoadMenu();
        }
        private void LoadMenu()
        {
            CrossCloudFirestore
                .Current
                .Instance
                .Collection("Menu")
                .WhereEqualsTo("key", id) //to be replaced with compound query
                .AddSnapshotListener((snapshot, error) =>
                {
                    if (!snapshot.IsEmpty)
                    {
                        foreach (var dc in snapshot.DocumentChanges)
                        {
                            switch (dc.Type)
                            {
                                case DocumentChangeType.Added:
                                    menuModels.Add(dc.Document.ToObject<MenuModel>());
                                    break;
                                case DocumentChangeType.Modified:

                                    break;
                                case DocumentChangeType.Removed:
                                    break;
                                default:
                                    break;
                            }
                        }
                    } 
                });
        }

        private void MenuCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as MenuModel;
            PopupNavigation.Instance.PushAsync(new ItemDetailDlg(data));
        }
    }
}