using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defult.Models;

namespace Defult.viewmodel
{
    public class ExcWorkModel
    {
        public Programs Program { get; set; }
        public ExcerciseItem[] Excercises { get; set; }
        public ExcerciseItem Exc { get; set; }
        public int wId { get; set; }
        public int wnum { get; set; }
        public int TotalExc { get; set; }
 

      
    }
}
