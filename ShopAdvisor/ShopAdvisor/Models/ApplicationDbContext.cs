using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAdvisor.Models
{
    public class ApplicationDbContext : DbContext
    {
            public ApplicationDbContext()
                : base("DefaultConection")
            {
                
            }
        public DbSet<Place> Places { set; get; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        }
}