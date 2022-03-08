using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class logo
    {
        [Key]
        public int logoid { get; set; }
        public string logophoto{ get; set; }
    }
}