using Anthenics.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anthenics.Models
{
    [Table("customer")]
    public class Customer : BaseViewModel
    {
        private int id;
        private string fullName;
        private int? age;
        private decimal? height;
        private decimal? weight;
        private bool isPersona;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set { SetProperty(ref id, value); }
        }
        [MaxLength(255)]
        public string FullName
        {
            get => fullName;
            set { SetProperty(ref fullName, value); }
        }
        public int? Age
        {
            get => age;
            set { SetProperty(ref age, value); }
        }
        public decimal? Height
        {
            get => height;
            set { SetProperty(ref height, value); }
        }
        public decimal? Weight
        {
            get => weight;
            set { SetProperty(ref weight, value); }
        }
        public bool IsPersona
        {
            get => isPersona;
            set { SetProperty(ref isPersona, value); }
        }

        public Customer() { isPersona = true; }
    }
}
