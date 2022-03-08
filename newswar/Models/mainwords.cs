using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class mainwords
    {
        [Key]
        public int wordid { get; set; }
        public string word { get; set; }
        public string wordcolor { get; set; }
    }
}