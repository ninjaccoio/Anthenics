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

            Device.SetFlags(new[] { "Expander_Experimental" });

            MainPage = new AppShell();
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
