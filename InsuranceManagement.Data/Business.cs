using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Data
{
    public class Business
    {
        [Key]
        public int BusinessID { get; set; }
        public string NameBusiness { get; set; }
        public string LegalNameBusiness { get; set; }
        public string BusinessMailingAddress { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessState { get; set; }
        public int BusinessZipCode { get; set; }
        public int YearBusinessStarted { get; set; }
        public string ServicesProvided { get; set; }
    }
}
