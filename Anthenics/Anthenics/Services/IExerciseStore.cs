using Anthenics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anthenics.Services
{
    public interface IExerciseStore
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync();
        Task<Exercise> GetExerciseAsync(int id);
        Task AddUpdateExerciseAsync(Exercise exercise);
        Task DeleteExercise(Exercise exercise);
    }
}
