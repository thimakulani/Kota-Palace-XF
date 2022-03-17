using Kota_Palace.Models;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kota_Palace.ViewModels
{
    public class AddToCartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string quantity;
        private string key;
        private string shopId;
        private string itemId;
        private string note;
        private string[] extras;

        public string ItemId { get { return itemId; } set { itemId = value; PropertyChanged(this, new PropertyChangedEventArgs("ItemId")); } }
        public string Note { get { return note; } set { note = value; PropertyChanged(this, new PropertyChangedEventArgs("Note")); } }
        public string ShopId { get { return shopId; } set { shopId = value; PropertyChanged(this, new PropertyChangedEventArgs("ShopId")); } }
        public string[] Extras { get { return extras; } set { extras = value; PropertyChanged(this, new PropertyChangedEventArgs("Extras")); } }
        public string Quantity { get { return quantity; } set { quantity = value; PropertyChanged(this, new PropertyChangedEventArgs("Quantity")); } }
        public string Key { get { return key; } set { key = value; PropertyChanged(this, new PropertyChangedEventArgs("Key")); } }

        public ICommand BtnAddToCart { get; set; }

        public AddToCartViewModel(MenuModel menuModel)
        {
            if (menuModel.Name != null)
            {
                this.extras = menuModel.Extras;
                this.itemId = menuModel.ItemId;
                this.Key = menuModel.Id;
            }
            BtnAddToCart = new Command(Upload);
        }
        private void FetchData()
        {

        }
        private async void Upload()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("quantity", quantity);
            data.Add("productId", ItemId);
            data.Add("shopId", shopId);
            data.Add("note", note);
            data.Add("Extras", extras);
            data.Add("timeDate", FieldValue.ServerTimestamp);
            data.Add("uid", "cLICVzAyEuYByOoxTma8Tp2Cq7w2");
            //if (chipAddOns.ChildCount > 0)
            //{
            //    for (int i = 0; i < chipAddOns.ChildCount; i++)
            //    {
            //        var chip = (Chip)chipAddOns.GetChildAt(i);
            //        if (chip.Checked)
            //        {
            //            AddOnItems.Add(chip.Text);
            //        }

            //    }
            //    data.Add("productAddOns", AddOnItems);

            //}
            //if (chipSources.ChildCount > 0)
            //{
            //    for (int i = 0; i < chipSources.ChildCount; i++)
            //    {
            //        var chip = (Chip)chipAddOns.GetChildAt(i);
            //        if (chip.Checked)
            //        {
            //            SourcesItems.Add(chip.Text);
            //        }
            //    }
            //    data.Add("productSources", AddOnItems);
            //}

            await CrossCloudFirestore
                .Current
                .Instance
                .Collection("Cart")
                .AddAsync(data);
        }

    }



}
