using Anthenics.ViewModels;
using SQLite;

namespace Anthenics.Models
{
    [Table("exercise")]
    public class Exercise : BaseViewModel
    {
        private int id;
        private string nome;
        private string type;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set { SetProperty(ref id, value); }
        }
        public string Nome
        {
            get => nome;
            set { SetProperty(ref nome, value); }
        }
        public string Type
        {
            get => type;
            set { SetProperty(ref type, value); }
        }
    }
}
