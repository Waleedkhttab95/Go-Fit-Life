using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Defult.Models
{
    public class ExcerciseItem
    {
        public int WId { get; set; }
        public int ExId { get; set; }
        public string ExName { get; set; }
        public string ExType { get; set; }
        public string ExBodyPart { get; set; }
        public string ExEquip { get; set; }
        public string ExSkill { get; set; }
        public string ExDuration { get; set; }
        public string ExDesc { get; set; }
        public string ExStepOne { get; set; }
        public string ExStepTwo { get; set; }
        public string ExVideo { get; set; }
    }
}
