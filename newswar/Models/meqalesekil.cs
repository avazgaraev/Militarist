using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class meqalesekil
    {
        [Key]
        public int sekilid { get; set; }
        public string sekilad { get; set; }
        public bool sekilmain { get; set; }

        public int Meqaleid { get; set; }
        public virtual meqale Meqale { get; set; }
    }
}