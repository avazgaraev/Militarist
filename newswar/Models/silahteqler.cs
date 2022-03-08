using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class silahteqler
    {
        [Key]
        public int teqid { get; set; }
        public string teqad { get; set; }


        public int silahid { get; set; }
        public virtual silahlar Silahlar { get; set; }
    }
}