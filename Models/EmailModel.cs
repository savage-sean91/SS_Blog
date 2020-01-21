﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SS_Blog.Models
{
    public class EmailModel
    {
        [Required, Display(Name ="Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Email"), EmailAddress]
        public string FromEmail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}