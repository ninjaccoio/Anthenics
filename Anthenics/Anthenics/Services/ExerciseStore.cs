using Anthenics.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Anthenics.Services
{
    public class ExerciseStore : IExerciseStore
    {
        private readonly SQLiteAsyncConnection connection;
        public ExerciseStore()
        {
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTableAsync<Exercise>();
        }

        public async Task AddUpdateExerciseAsync(Exercise exercise)
        {
            if (exercise.Id != 0)
                await connection.UpdateAsync(exercise);
            else
                await connection.InsertAsync(exercise);
        }

        public async Task DeleteExercise(Exercise exercise)
        {
            await connection.DeleteAsync(exercise);
        }

        public async Task<Exercise> GetExerciseAsync(int id)
        {
            return await connection.FindAsync<Exercise>(id);
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync()
        {
            return await connection.Table<Exercise>().ToListAsync();
        }
    }
}
