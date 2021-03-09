using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Defult.Models
{
    public class Workout_Excercises
    {
        [Key]
        public int WE_id { get; set; }
        [ForeignKey("Excercise")]
        public int WE_ExId { get; set; }
        [ForeignKey("Workout")]
        public int WE_WId { get; set; }
    }
}
