using Kota_Palace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kota_Palace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailDlg
    {
        private readonly MenuModel data;

        public ItemDetailDlg(MenuModel data)
        {
            InitializeComponent();
            this.data = data;
        }
    }
}