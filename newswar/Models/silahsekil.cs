using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class silahsekil
    {
        [Key]
        public int sekilid { get; set; }
        public string sekilad { get; set; }
        public bool sekilmain { get; set; }

        public int silahid { get; set; }
        public virtual silahlar Silahlar { get; set; }
    }
}