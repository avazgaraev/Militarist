using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class silahlar
    {
        [Key]
        public int silahid { get; set; }
        public string silahad { get; set; }
        public string silahdetal { get; set; }

        public virtual ICollection<silahsekil> Silahsekils { get; set; }
        public virtual ICollection<silahteqler> Silahteqlers { get; set; }

        public int subcategoryid { get; set; }
        public virtual subcategory Subcategory { get; set; }
    }
}