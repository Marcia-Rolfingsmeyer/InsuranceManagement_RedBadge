using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.Auto
{
    public class AutoListItem
    {
        [Display(Name = "Auto ID")]
        public int AutoID { get; set; }

        public string Make { get; set; }

        [Display(Name = "Model")]
        public string CarModel { get; set; }

        public int Year { get; set; }

        [Display(Name = "VIN Number")]
        public string VINNumber { get; set; }

    }
}
