using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace newswar.Models
{
    public class context: DbContext
    {
        public DbSet<biz> bizs { get; set; }
        public DbSet<elaqe> elaqes { get; set; }
        public DbSet<mainwords> mainwords { get; set; }
        public DbSet<navbar> navbars { get; set; }
        public DbSet<logo> logos { get; set; }
        public DbSet<altbanner> altbanners { get; set; }
        public DbSet<kecidbanner> kecidbanners { get; set; }
        public DbSet<meqale> meqales { get; set; }
        public DbSet<meqbanner> meqbanners { get; set; }
        public DbSet<meqalesekil> meqalesekils{ get; set; }
        public DbSet<teqler> teqlers{ get; set; }
        public DbSet<silahlar> silahlars{ get; set; }
        public DbSet<silahsekil> silahsekils{ get; set; }
        public DbSet<silahteqler> silahteqlers{ get; set; }
        public DbSet<category> categories{ get; set; }
        public DbSet<subcategory> subcategories{ get; set; }
        public DbSet<visitor> visitors{ get; set; }
    }
}