using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceManagement.Models
{
    public class ClientCreate
    {
        public int ClientID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Must have 5 characters")]
        [MaxLength(5, ErrorMessage = "ZipCode should have 5 characters")]
        public int ZipCode { get; set; }

        public string County { get; set; }

        public string Township { get; set; }

        [Display(Name = "Social Security Number or Tax ID")]
        public string SSNumberTaxID { get; set; }
    }
}
