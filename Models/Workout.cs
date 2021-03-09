using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Defult.Models
{
    public class Workout
    {
        [Key]
        public int Wid { get; set; }
        public string WName { get; set; }
        public string WArea { get; set; }
        public string WLevel { get; set; }
        public string WType { get; set; }
    }
}
