using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.Auto
{
    public class AutoCreate
    {
        [Display(Name ="Auto ID")]
        public int AutoID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string CarModel { get; set; }

        [Required]
        public int Year { get; set; }

        public int Mileage { get; set; }

        [Display(Name = "VIN Number")]
        public string VINNumber { get; set; }

        [Display(Name = "Current Carrier")]
        public string CurrentCarrier { get; set; }

        [Display(Name = "Current Deductible")]
        public int CurrentDeductible { get; set; }

        [Display(Name = "Policy Number")]
        public string PolicyNumber { get; set; }

        [Display(Name = "Policy Start Date")]
        public DateTimeOffset? PolicyStartDate { get; set; }

        [Display(Name = "Policy End Date")]
        public DateTimeOffset? PolicyEndDate { get; set; }
        
        [Display(Name = "Liability Limit")]
        public int LiabilityLimit { get; set; }

        [Display(Name = "Losses Last Five Years")]
        public bool LossesLastFiveYears { get; set; }

        [Display(Name = "Year of Loss")]
        public int YearOfLoss { get; set; }

        [Display(Name = "Claims Last Five Years")]
        public bool ClaimsLastFiveYears { get; set; }

        [Display(Name = "Most Recent Amount Of Claim")]
        public int AmountOfClaim { get; set; }

        [Display(Name = "Most Recent Year of Claim")]
        public int YearOfClaim { get; set; }
    }
}
