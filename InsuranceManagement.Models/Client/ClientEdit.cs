using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models.Client
{
    public class ClientEdit
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

        public int? PersonalAutoID { get; set; }
        public int? CommercialAutoID { get; set; }

    }
}
