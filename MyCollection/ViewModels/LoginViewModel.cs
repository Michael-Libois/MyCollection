using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.ViewModels
{

    public class LoginViewModel
    {

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool AcceptShared { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public string ReturnUrl { get; set; }
    }
}
