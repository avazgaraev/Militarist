using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class subcategory
    {
        [Key]
        public int subid { get; set; }
        public string subaname { get; set; }

        public ICollection<meqale> meqales { get; set; }
        public ICollection<silahlar> silahlars { get; set; }

        public int categoryid { get; set; }
        public virtual category Category { get; set; }
    }
}