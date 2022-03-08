using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class teqler
    {
        [Key]
        public int teqid { get; set; }
        public string teqad { get; set; }
        

        public int Meqaleid { get; set; }
        public virtual meqale Meqale { get; set; }
    }
}