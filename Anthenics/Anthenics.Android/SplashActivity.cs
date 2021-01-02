﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.AppCompat.App;

namespace Anthenics.Droid
{
    [Activity(Theme = "@style/Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            var mainIntent = new Intent(Application.Context, typeof(MainActivity));

            if (Intent.Extras != null)
            {
                mainIntent.PutExtras(Intent.Extras);
            }
            mainIntent.SetFlags(ActivityFlags.SingleTop);

            StartActivity(mainIntent);

        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}