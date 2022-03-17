using Kota_Palace.Models;
using Plugin.CloudFirestore;
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
    public partial class DashboardPage : ContentPage
    {
        private readonly ObservableCollection<ShopModel> shopModels = new ObservableCollection<ShopModel>();
        public ObservableCollection<ShopModel> ShopModels { get { return shopModels; } }
        public DashboardPage()
        {
            InitializeComponent();
            ShopCollection.ItemsSource = ShopModels;
            LoadShops();
        }
        private void LoadShops()
        {
            CrossCloudFirestore
                .Current
                .Instance
                .Collection("Admins")
                .AddSnapshotListener((snapshot, errors) =>
                {
                    if (!snapshot.IsEmpty)
                    {
                        foreach (var dc in snapshot.DocumentChanges)
                        {
                            var data = dc.Document.ToObject<ShopModel>();
                            switch (dc.Type)
                            {
                                case DocumentChangeType.Added:
                                    shopModels.Add(data);
                                    break;
                                case DocumentChangeType.Modified:
                                    if(dc.Document != null)
                                    {
                                        int pos = shopModels.ToList().FindIndex(x => x.Id == data.Id);
                                        if(pos > -1)
                                        {
                                            shopModels[pos] = (data);
                                        }
                                    }

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

        private void ShopCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = e.CurrentSelection.FirstOrDefault() as ShopModel;
            if (data != null)
            {
                Navigation.PushModalAsync(new ShopDetailedPage(data.Id));
            }
            ShopCollection.SelectedItem = null;
        }
    }
}