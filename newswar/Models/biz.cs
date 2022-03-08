using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class biz
    {
        [Key]
        public int bizid { get; set; }
        public string sosialad { get; set; }
        public string sosiallink { get; set; }

    }
}