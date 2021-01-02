using Anthenics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anthenics.Models
{
    public class WorkoutExercise : BaseViewModel
    {
        private int id;
        private List<Exercise> exercises;

        public int Id
        {
            get => id;
            set { SetProperty(ref id, value); }
        }
        public List<Exercise> Exercises
        {
            get => exercises;
            set { SetProperty(ref exercises, value); }
        }
    }
}
