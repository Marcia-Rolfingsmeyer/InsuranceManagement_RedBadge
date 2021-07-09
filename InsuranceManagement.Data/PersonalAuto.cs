using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Data
{
    public class PersonalAuto : Auto
     {
        [Display(Name = "Peronal Auto ID")]
        public int PersonalAutoID { get; set; }

        [Display(Name = "Full Coverage")]
        public bool IsFullCoverage { get; set; }

        [Display(Name = "Liability")]
        public bool IsLiability { get; set; }

        [Display(Name = "Uninsured Motorist Coverage")]
        public bool IsUninsuredMotorist { get; set; }

        [Display(Name = "Car Rental Coverage")]
        public bool IsCarRental { get; set; }

        [Display(Name = "Medical Coverage")]
        public bool IsMedicalCoverage { get; set; }
    }
}
