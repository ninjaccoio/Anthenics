using Anthenics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anthenics.Services
{
    public interface IWorkoutStore
    {
        Task<IEnumerable<Workout>> GetWorkoutsAsync();
        Task<Workout> GetWorkout(int id);
        Task AddUpdateWorkout(Workout workout);
        Task DeleteWorkout(Workout workout);
    }
}
