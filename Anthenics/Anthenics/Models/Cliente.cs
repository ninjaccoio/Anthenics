using SQLite;

namespace Anthenics.Models
{
    [Table("clienti")]
    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Nome { get; set; }
        [MaxLength(255)]
        public string Cognome { get; set; }
        public int? Eta { get; set; }
        public decimal? Altezza { get; set; }
        public decimal? Peso { get; set; }
    }
}
