using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Data
{
    public class PersonalAuto : Auto
     {
        
        //public int PersonalAutoID { get; set; }

        public bool IsFullCoverage { get; set; }

        public bool IsLiability { get; set; }

        public bool IsUninsuredMotorist { get; set; }

        public bool IsCarRental { get; set; }

        public bool IsMedicalCoverage { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
