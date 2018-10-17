using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiOdata.Models
{
    public class OdataContext : DbContext
    {
        public OdataContext()
            : base("name=OdataContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}