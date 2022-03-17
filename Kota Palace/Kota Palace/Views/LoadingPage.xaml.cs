using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Kota_Palace.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }
        private void Build()
        {
            Plugin.FirebaseAuth.CrossFirebaseAuth.Current
                .Instance
                .AuthState += Instance_AuthState;
        }
        private void Instance_AuthState(object sender, Plugin.FirebaseAuth.AuthStateEventArgs e)
        {
            if(e.Auth.CurrentUser == null)
            {

            }
            else
            {
                Application.Current.MainPage = new AppShell();
            }
        }
    }
}