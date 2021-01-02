using Anthenics.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anthenics.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutsPage : ContentPage
    {
        WorkoutsViewModel viewModel;
        public WorkoutsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new WorkoutsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}