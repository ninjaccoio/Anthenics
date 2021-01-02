using Anthenics.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anthenics.Models
{
    [Table("customer")]
    public class Workout : BaseViewModel
    {
        private int id;
        private int idCustomer;
        private List<WorkoutExercise> workoutExercises;
        private DateTime date;
        private bool like;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set { SetProperty(ref id, value); }
        }
        public int IdCustomer
        {
            get => idCustomer;
            set { SetProperty(ref idCustomer, value); }
        }
        public List<WorkoutExercise> WorkoutExercises
        {
            get => workoutExercises;
            set { SetProperty(ref workoutExercises, value); }
        }
        public DateTime Date
        {
            get => date;
            set { SetProperty(ref date, value); }
        }
        public bool Like
        {
            get => like;
            set { SetProperty(ref like, value); }
        }
    }
}
