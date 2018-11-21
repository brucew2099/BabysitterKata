using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BabysitterKata.Models
{
    public class CalculationViewModel
    {
        public string Family { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}