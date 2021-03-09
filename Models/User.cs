using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Defult.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public int Password { get; set; }
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public int Repassword { get; set; }

        public int Calories { get; set; }
        public int Protin { get; set; }
        public int Carb { get; set; }
        public int Fat { get; set; }
        [Required(ErrorMessage = "Please enter your weight Goal")]
        public int GoalWieght { get; set; }
        [Required(ErrorMessage = "Please enter your Weight")]
        public int Weight { get; set; }
        [Required(ErrorMessage = "Please enter your Height")]
        public float Height { get; set; }
        [Required(ErrorMessage = "Please enter your Age")]
        public int Age { get; set; }
        public Programs  Programs { get; set; }
        public int ProgramsId { get; set; }
        public string imgPath { get; set; }
    }
}
