using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class navbar
    {
        [Key]
        public int navbarid { get; set; }
        public string navbarname { get; set; }
    }
}