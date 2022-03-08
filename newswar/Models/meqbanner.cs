using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newswar.Models
{
    public class meqbanner
    {
        [Key]
        public int bannerid { get; set; }
        public string bannerad { get; set; }
        public string banneradreng { get; set; }
        public string sekil { get; set; }
        public bool available { get; set; }
    }
}