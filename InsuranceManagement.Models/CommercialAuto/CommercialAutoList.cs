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
        [Display(Name = "Number in Fleet")]
        public int NumberInFleet { get; set; }

        //FK
        public int? ClientID { get; set; }
        public virtual ClientList Client { get; set; }
    }
}
