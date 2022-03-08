using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class visitor
    {
        [Key]
        public int visitorid { get; set; }
        public string MacId { get; set; }
        public string IpAddress { get; set; }

        public int meqaleid { get; set; }
        public virtual meqale Meqale { get; set; }
    }
}