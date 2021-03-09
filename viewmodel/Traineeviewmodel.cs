using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defult.Models;

namespace Defult.viewmodel
{
    public class Traineeviewmodel
    {
        public IEnumerable<Programs> Programs { set; get; }
        public User User { set; get; }
       
    }
}
