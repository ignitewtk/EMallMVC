using System;
using Microsoft.EntityFrameworkCore;
using EMallMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMallMVC.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<EMallMVC.Models.Product> Product { get; set; }

    }
}
