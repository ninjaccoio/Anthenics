using Anthenics.Models;
using Anthenics.Services;
using Anthenics.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anthenics.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        private readonly CustomerStore customerStore = new CustomerStore();

        #region Properties
        private Customer customer;
        private ObservableCollection<Customer> customers;

        public Customer Customer
        {
            get => customer;
            set 
            { 
                SetProperty(ref customer, value);
                if(value != null) GoEditCustomer();
            }
        }
        public ObservableCollection<Customer> Customers
        {
            get => customers;
            set { SetProperty(ref customers, value); }
        }
        #endregion
        public CustomersViewModel()
        {
            Task.Run(async () =>
            {
                Customers = new ObservableCollection<Customer>(await customerStore.GetCustomersAsync());
            });
        }

        #region Commands
        public ICommand GoAddCustomerCommand => new Command( () => GoAddCustomer());
        public ICommand GoBackCommand => new Command(() => GoBack());
        #endregion

        #region Methods
        private void GoEditCustomer()
        {
            Shell.Current.GoToAsync($"{nameof(AddEditCustomerPage)}?Id={customer.Id}");
        }
        private static void GoAddCustomer()
        {
            Shell.Current.GoToAsync(nameof(AddEditCustomerPage));
        }
        private static void GoBack()
        {
            Shell.Current.Navigation.PopAsync();
            //Shell.Current.GoToAsync(".."); // non mi fa vedere l'animazione
            //Shell.Current.GoToAsync($"//{nameof(CustomersPage)}/{nameof(AddEditCustomerPage)}");
        }
        #endregion
    }
}
