using Anthenics.Models;
using Anthenics.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Anthenics.ViewModels
{
    public class AddClienteViewModel
    {
        private readonly ClienteStore clienteStore = new ClienteStore();

        private ObservableCollection<Cliente> clienti;

        public ObservableCollection<Cliente> Clienti
        {
            get { return clienti; }
            set { clienti = value; }
        }

        public AddClienteViewModel()
        {
            Task.Factory.StartNew(async () =>
            {
                Clienti = new ObservableCollection<Cliente>(await clienteStore.GetClientiAsync());
            });
            
        }
    }
}
