using InsuranceManagement.Models.Auto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.CommercialAuto
{
    public class CommercialAutoDetail : AutoDetail
    {
        [Display(Name = "Number in Fleet")]
        public int NumberInFleet { get; set; }

        [Display(Name = "Number of Drivers")]
        public int NumberOfDrivers { get; set; }

        [Display(Name = "DOT Number")]
        public int DOTNumber { get; set; }

        [Display(Name = "Radius of Operation (miles)")]
        public int RadiusOfOperation { get; set; }

        [Display(Name = "Comp Deductible Fleet")]
        public int CompDeductible { get; set; }

        [Display(Name = "Collision Deductible")]
        public int CollisionDeductible { get; set; }

        public int? ClientID { get; set; }
        public virtual ClientList Client { get; set; }

    }
}
