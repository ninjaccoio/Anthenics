using Anthenics.Models;
using Anthenics.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anthenics.ViewModels
{
    //ricevo come parametro l'id del cliente da modificare
    [QueryProperty(nameof(Id), nameof(Id))]
    public class AddEditCustomerViewModel : BaseViewModel
    {
        private readonly CustomerStore customerStore = new CustomerStore();

        #region Properties
        private int id;
        
        private Color switchBackgroundColor1 = Color.FromHex("#FF0000");
        private Color switchTextColor1 = Color.FromHex("#FFFFFF");
        private Color switchBackgroundColor2 = Color.FromHex("#EDEDED");
        private Color switchTextColor2 = Color.FromHex("#FF0000");
        private string buttonText = "Salva";
        private Customer customer;
        private bool showFullNameError;

        public string Id
        {
            set
            {
                id = int.Parse(value);
                LoadCustomer();
            }
        }

        public Customer Customer
        {
            get => customer;
            set 
            { 
                SetProperty(ref customer, value);
                if (customer.IsPersona)
                    SetState1();
                else
                    SetState2();
            }
        }
        public bool ShowFullNameError
        {
            get => showFullNameError;
            set { SetProperty(ref showFullNameError, value); }
        }
        public string SwitchText1 { get; set; } = "Persona";
        public string SwitchText2 { get; set; } = "Gruppo";
        public Color SwitchBackgroundColor1
        {
            get => switchBackgroundColor1;
            set { SetProperty(ref switchBackgroundColor1, value); }
        }
        public Color SwitchTextColor1
        {
            get => switchTextColor1;
            set { SetProperty(ref switchTextColor1, value); }
        }
        public Color SwitchBackgroundColor2
        {
            get => switchBackgroundColor2;
            set { SetProperty(ref switchBackgroundColor2, value); }
        }
        public Color SwitchTextColor2
        {
            get => switchTextColor2;
            set { SetProperty(ref switchTextColor2, value); }
        }
        public string ButtonText
        {
            get => buttonText;
            set { SetProperty(ref buttonText, value); }
        }

        #endregion

        public AddEditCustomerViewModel() { Customer = new Customer(); }

        #region Commands
        public ICommand SaveUpdateCommand => new Command(() => SaveUpdate());
        public ICommand SetState1Command => new Command(() => SetState1());
        public ICommand SetState2Command => new Command(() => SetState2());
        #endregion

        #region Methods
        private void SaveUpdate()
        {
            Task.Factory.StartNew(async () =>
            {
                IsBusy = true;

                if (!string.IsNullOrEmpty(customer.FullName) || !string.IsNullOrWhiteSpace(customer.FullName))
                {
                    ShowFullNameError = false;

                    await customerStore.AddUpdateCustomer(customer);

                    if (customer.Id != 0)
                        Device.BeginInvokeOnMainThread(async () => await Shell.Current.GoToAsync(".."));

                }
                else
                    ShowFullNameError = true;

                IsBusy = false;
            });
        }

        private void LoadCustomer()
        {
            ButtonText = "Aggiorna";
            Task.Factory.StartNew(async () =>
            {
                IsBusy = true;

                Customer = await customerStore.GetCustomer(id);

                IsBusy = false;
            });
        }
        private void SetState1()
        {
            SwitchBackgroundColor1 = Color.FromHex("#FF0000");
            SwitchBackgroundColor2 = Color.FromHex("#EDEDED");
            SwitchTextColor1 = Color.FromHex("#FFFFFF");
            SwitchTextColor2 = Color.FromHex("#FF0000");
            Customer.IsPersona = true;
        }
        private void SetState2()
        {
            SwitchBackgroundColor1 = Color.FromHex("#EDEDED");
            SwitchBackgroundColor2 = Color.FromHex("#FF0000");
            SwitchTextColor1 = Color.FromHex("#FF0000");
            SwitchTextColor2 = Color.FromHex("#FFFFFF");
            Customer.IsPersona = false;
        }
        #endregion

    }
}
