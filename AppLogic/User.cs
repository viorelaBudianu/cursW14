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
        
        public string UserName { get; set; }
       
        public string Email { get; set; }
        
        public string City { get; set; }
        
        public string Description { get; set; }
       
        public string Street { get; set; }

        
    }
}
