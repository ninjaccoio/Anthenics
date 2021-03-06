﻿using Anthenics.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anthenics
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUxNzgxQDMxMzgyZTMzMmUzMG1VMlcwSHdtQWdidmF0SlhET05KZDAvc2pSYURTOUxPOURxR0xwRVJQLzQ9");
            
            InitializeComponent();

            DependencyRegister();

            Device.SetFlags(new[] { "Expander_Experimental" });

            MainPage = new AppShell();
        }

        private void DependencyRegister()
        {
            //Mocking
            DependencyService.Register<IWorkoutStore, WorkoutMockStore>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
