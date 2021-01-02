using Anthenics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Anthenics.Services
{
    public class WorkoutMockStore : IWorkoutStore
    {
        public Task AddUpdateWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWorkout(Workout workout)
        {
            throw new NotImplementedException();
        }

        public Task<Workout> GetWorkout(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Workout>> GetWorkoutsAsync()
        {
            await Task.Delay(1000);

            var workouts = new List<Workout>
            {
                new Workout()
                {
                    Id = 1,
                    Date = new DateTime(2021, 01, 03),
                    IdCustomer = 1,
                    Like = false,
                    WorkoutExercises = new List<WorkoutExercise>()
                    {
                        new WorkoutExercise()
                        {
                            Id = 1,
                            Exercises = new List<Exercise>()
                            {
                                new Exercise()
                                {
                                    Id = 1,
                                    Nome = "Planche",
                                    Type = "Sec"
                                }
                            }
                        },
                        new WorkoutExercise()
                        {
                            Id = 2,
                            Exercises = new List<Exercise>()
                            {
                                new Exercise()
                                {
                                    Id = 2,
                                    Nome = "Front Lever",
                                    Type = "Sec"
                                }
                            }
                        },
                    } 
                }
            };

            return workouts;
        }
    }
}
