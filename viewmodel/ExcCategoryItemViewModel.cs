using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Defult.Models;

namespace Defult.viewmodel
{
    public class ExcCategoryItemViewModel
    {
        public ExcerciseItemCategory[] ExcerciseItemCat { get; set; }
        public ExcerciseItemCategory ExcItemCat { get; set; }
        public int BodyPartId { get; set; }
        public int TotalExc { get; set; }
    }
}
