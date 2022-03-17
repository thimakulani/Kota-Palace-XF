using Kota_Palace.Models;
using Kota_Palace.ViewModels;
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
    public partial class ProfilePage : ContentPage
    {
      
        public ProfilePage()
        {
            InitializeComponent();
            MenuModel menuModel = new MenuModel();
            BindingContext = new AddToCartViewModel(menuModel);
            
            //ImageUrl            
        }
      
    }
}