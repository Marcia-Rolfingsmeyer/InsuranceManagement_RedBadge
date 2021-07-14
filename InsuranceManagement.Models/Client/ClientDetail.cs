using InsuranceManagement.Models.CommercialAuto;
using InsuranceManagement.Models.PersonalAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.Client
{
    public class ClientDetail
    {
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Display(Name ="Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual List<PersonalAutoList> PersonalAutos { get; set; }

        public virtual List<CommercialAutoList> CommercialAutos { get; set; }

    }
}
