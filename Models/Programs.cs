using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Defult.Models
{
    public class Programs
    {
        [Key]
        public int Id { get; set; }        
        public string P_name { get; set; }
        public string P_Type { get; set; }
        public string P_Level { get; set; }
        public string P_Area { get; set; }

    }
}
