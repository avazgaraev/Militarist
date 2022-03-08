using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class elaqe
    {
        [Key]
        public int bizid { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}