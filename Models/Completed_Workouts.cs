using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Defult.Models
{
    public class Completed_Workouts
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [ForeignKey("Program_Workout")]
        public int PW_PId { get; set; }
        [ForeignKey("Program_Workout")]
        public int PW_WId { get; set; }
        public bool Completed { get; set; }

    }
}
