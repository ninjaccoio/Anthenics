using Anthenics.Models;
using Anthenics.Services;
using Anthenics.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Anthenics.ViewModels
{
    public class WorkoutsViewModel : BaseViewModel
    {
        #region Properties
        private Workout selectedWorkout;
        public Workout SelectedWorkout
        {
            get => selectedWorkout;
            set
            {
                SetProperty(ref selectedWorkout, value);
                OnWorkoutSelected(value);
            }

        }
        public ObservableCollection<Workout> Workouts { get; }
        #endregion

        #region Commands
        public ICommand LoadLikeWorkoutsCommand => new Command(() => LoadLikeWotkouts());
        public ICommand GoCustomersCommand => new Command(() => GoCustomers());
        public ICommand GoExercisesCommand => new Command(() => GoExercises());
        #endregion

        public WorkoutsViewModel()
        {
            Workouts = new ObservableCollection<Workout>();
        }

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
        public void OnAppearing()
        {
            Task.Factory.StartNew(async () =>
            {
                try
                {
                    IsBusy = true;

                    Workouts.Clear();

                    var items = await WorkoutStore.GetWorkoutsAsync();

                    foreach(var item in items)
                    {
                        Workouts.Add(item);
                    }
                }
                catch(Exception ex)
                {

                }finally
                {
                    IsBusy = false;
                }
            });
        }

        async void OnWorkoutSelected(Workout item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"{nameof(PianificationDetailPage)}?{nameof(PianificationDetailViewModel.Id)}={item.Id}");
        }
        #endregion

    }
}
