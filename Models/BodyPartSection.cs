using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Defult.Models
{
    public class BodyPartSection
    {
        [Key]
        public int BPartId { get; set; }
        public string BPartName { get; set; }

    }
}
