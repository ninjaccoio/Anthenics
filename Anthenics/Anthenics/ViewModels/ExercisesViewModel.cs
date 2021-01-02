using Anthenics.Models;
using Anthenics.Services;
using Anthenics.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anthenics.ViewModels
{
    public class ExercisesViewModel : BaseViewModel
    {
        private readonly ExerciseStore exerciseStore = new ExerciseStore();

        #region Properties
        private ObservableCollection<Exercise> exercises;

        public ObservableCollection<Exercise> Exercises
        {
            get => exercises;
            set { SetProperty(ref exercises, value); }
        }
        #endregion
        public ExercisesViewModel()
        {
            Task.Run(async () =>
            {
                Exercises = new ObservableCollection<Exercise>(await exerciseStore.GetExercisesAsync());
            });
        }

        #region Commands
        public ICommand GoEditExerciseCommand => new Command((x) => GoEditExercise(x));
        public ICommand GoAddExerciseCommand => new Command(() => GoAddExercise());
        #endregion

        #region Methods
        private static void GoEditExercise(object exercise)
        {
            var test = (Exercise)exercise;
            Shell.Current.GoToAsync(nameof(AddEditExercisePage)); // e gli passo l'id come parametro
            throw new NotImplementedException();
        }
        private static void GoAddExercise()
        {
            Shell.Current.GoToAsync(nameof(AddEditExercisePage));
        }
        #endregion
    }
}
