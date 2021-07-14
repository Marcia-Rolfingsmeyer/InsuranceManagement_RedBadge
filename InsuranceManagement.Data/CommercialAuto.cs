using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Data
{
    public class CommercialAuto : Auto
    {
        //public int CommercialAutoID { get; set; }

        public int NumberInFleet { get; set; }
        public int NumberOfDrivers { get; set; }
        public int DOTNumber { get; set; }
        public int RadiusOfOperation { get; set; }
        public int CompDeductible { get; set; }
        public int CollisionDeductible { get; set; }
       
        [ForeignKey(nameof(Client))]
        public int? ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
