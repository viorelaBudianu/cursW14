﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerApp.Models
{
    public class UserDeleteViewModel
    {
        public int? Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string Street { get; set; }
    }
}