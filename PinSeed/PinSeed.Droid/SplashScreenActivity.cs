using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PinSeed.Droid
{
    [Activity(Label = "PinSeed", 
        Icon = "@drawable/icon",
        Theme = "@style/splashscreen",
        MainLauncher = true,
        NoHistory = true)]
    public class SplashScreenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            this.Window.ClearFlags(WindowManagerFlags.Fullscreen);
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }


    }
}