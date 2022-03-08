using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class kecidbanner
    {
        [Key]
        public int kecidbannerid { get; set; }
        public string bannerphoto { get; set; }
        public string bannertext { get; set; }
    }
}