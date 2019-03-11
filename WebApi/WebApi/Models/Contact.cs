using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Contact
    {
        public string bname { get; set; }
        public string bemail { get; set; }
        public string bmobile { get; set; }
        public string bsubject { get; set; }
        public string bmessage { get; set; }
    }
}