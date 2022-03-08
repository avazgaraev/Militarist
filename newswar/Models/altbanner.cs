using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class altbanner
    {
        [Key]
        public int bannerid { get; set; }
        
        public string bannerad { get; set; }
        public string bannercolor{ get; set; }

        public string bannerphoto { get; set; }
        public string bannerbuttontext { get; set; }
        public string bannerbuttoncolor { get; set; }
        public string bannerbuttonbgcolor { get; set; }
    }
}