using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Defult.Models
{
    public class Program_Workouts
    {
        [Key]
        public int PW_Id { get; set; }
        [ForeignKey("Programs")]
        public int PW_PId { get; set; }
        [ForeignKey("Workout")]
        public int PW_WId { get; set; }
        public int P_Day { get; set; }
    }
}
