using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class meqale
    {
        [Key]
        public int meqaleid { get; set; }
        public string basliq { get; set; }
        public string qisadetal { get; set; }
        public string uzundetal { get; set; }
        public int meqalebaxissayi { get; set; }
        public DateTime meqaletarix { get; set; }

        public virtual ICollection<teqler> Teqlers { get; set; }
        public string teqler { get; set; }
        public virtual ICollection<meqalesekil> Meqalesekils { get; set; }

        public int subcategoryid { get; set; }
        public virtual subcategory Subcategory { get; set; }
    }
}