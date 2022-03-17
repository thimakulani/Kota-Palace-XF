using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kota_Palace.Droid
{
    [Activity(Label = "Kota Palace", Icon = "@drawable/logo_pan", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Set our view from the "main" layout resource
            
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startWork = new Task(() =>
            {
                Task.Delay(3000);
            });
            startWork.ContinueWith(t =>
            {

                Intent intent = new Intent(Application.Context, typeof(MainActivity));
                StartActivity(intent);

            }, TaskScheduler.FromCurrentSynchronizationContext());
            startWork.Start();
        }

    }
}