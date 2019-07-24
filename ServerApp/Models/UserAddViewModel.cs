using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServerApp.Models
{

    public class UserAddViewModel // aici tre sa fac, nu in BusinessLogic 
    {
        public int? Id { get; set; }
        [Display(Name ="UserName")]     
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
    }
}