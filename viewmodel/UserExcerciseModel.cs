using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defult.Models;

namespace Defult.viewmodel
{
    public class UserExcerciseModel
    {

        public Programs Program { set; get; }
        public ProgramWorkoutsItem[] ProgramWorkouts { get; set; }
        public Completed_WorkoutItem[] CompletedWorkouts { get; set; }
        public Completed_Workouts CompWorkouts { get; set; }
        public Completed_Workouts[] Com { get; set; }
    }
}
