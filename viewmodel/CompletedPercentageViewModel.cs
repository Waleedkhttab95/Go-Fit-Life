using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defult.Models;

namespace Defult.viewmodel
{
    public class CompletedPercentageViewModel
    {
        public int Length { get; set; }
        public User user { get; set; }
        public Programs Program { set; get; }
    }
}
