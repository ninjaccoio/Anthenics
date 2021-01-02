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
    public class WorkoutsViewModel : BaseViewModel
    {
        private readonly WorkoutStore workoutStore = new WorkoutStore();

        #region Properties
        #region Private
        private ObservableCollection<Workout> workouts;
        #endregion
        #region Public
        public ObservableCollection<Workout> Workouts
        {
            get => workouts;
            set { SetProperty(ref workouts, value); }
        }
        #endregion
        #endregion

        public WorkoutsViewModel()
        {
            Task.Run(async () =>
            {
                Workouts = new ObservableCollection<Workout>(await workoutStore.GetWorkoutsAsync());
            });

        }

        #region Commands
        public ICommand LoadLikeWorkoutsCommand => new Command(() => LoadLikeWotkouts());
        public ICommand GoCustomersCommand => new Command(() => GoCustomers());
        public ICommand GoExercisesCommand => new Command(() => GoExercises());
        #endregion

        #region Methods
        private void GoCustomers()
        {
            Shell.Current.GoToAsync(nameof(CustomersPage));
        }
        private void GoExercises()
        {
            Shell.Current.GoToAsync(nameof(ExercisesPage));
        }
        private static void LoadLikeWotkouts()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
