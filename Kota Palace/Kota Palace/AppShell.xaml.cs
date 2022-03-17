using Kota_Palace.Views;
using Xamarin.Forms;

namespace Kota_Palace
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
           // Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
