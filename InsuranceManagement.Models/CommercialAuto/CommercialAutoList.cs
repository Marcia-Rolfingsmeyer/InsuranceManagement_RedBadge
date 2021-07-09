using InsuranceManagement.Models.Auto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.CommercialAuto
{
    public class CommercialAutoList : AutoListItem
    {
        public int CommercialAutoID { get; set; }

        [Display(Name = "Number in Fleet")]
        public int NumberInFleet { get; set; }
    }
}
