using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApp.Models
{

    public class UserAddViewModel // aici tre sa fac, nu in BusinessLogic 
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}