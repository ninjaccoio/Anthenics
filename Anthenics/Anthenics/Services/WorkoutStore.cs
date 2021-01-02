using Anthenics.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Anthenics.Services
{
    public class WorkoutStore : IWorkoutStore
    {
        private readonly SQLiteAsyncConnection connection;
        public WorkoutStore()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTableAsync<Workout>();
        }
        public async Task AddUpdateWorkout(Workout workout)
        {
            if (workout.Id != 0)
                await connection.UpdateAsync(workout);
            else
                await connection.InsertAsync(workout);
        }

        public async Task DeleteWorkout(Workout workout)
        {
            await connection.DeleteAsync(workout);
        }

        public async Task<Workout> GetWorkout(int id)
        {
            return await connection.FindAsync<Workout>(id);
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsAsync()
        {
            return await connection.Table<Workout>().ToListAsync();
        }
    }
}
