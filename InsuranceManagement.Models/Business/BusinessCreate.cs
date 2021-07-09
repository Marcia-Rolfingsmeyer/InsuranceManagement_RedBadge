using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.Business
{
    public class BusinessCreate
    {
        public int BusinessID { get; set; }

        [Display(Name = "Name of Business DBA")]
        public string NameBusiness { get; set; }

        [Display(Name = "Legal Name of Business")]
        public string LegalNameBusiness { get; set; }

        [Display(Name = "Business Mailing Address")]
        public string BusinessMailingAddress { get; set; }

        [Display(Name = "Business City")]
        public string BusinessCity { get; set; }

        [Display(Name = "Business State")]
        public string BusinessState { get; set; }

        [Display(Name = "Business Zip Code")]
        public int BusinessZipCode { get; set; }

        [Display(Name = "Year Business Started")]
        public int YearBusinessStarted { get; set; }

        [Display(Name = "Services Provided")]
        public string ServicesProvided { get; set; }
    }
}
