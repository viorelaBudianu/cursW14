using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class User //entitatea de business
    {
        public int? Id { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="City")]
        public string City { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Display(Name ="Street")]
        public string Street { get; set; }

        
    }
}
