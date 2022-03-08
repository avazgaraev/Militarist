using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class category
    {
        [Key]
        public int categoryid { get; set; }
        public string categoryname{ get; set; }

        public ICollection<subcategory> subcategories { get; set; }
    }
}