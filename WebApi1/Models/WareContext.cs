using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi1.Models
{
    public class WareContext : DbContext
    {
        public WareContext(DbContextOptions<WareContext> options) : base(options)
        {

        }

        public DbSet<Ware> Waren { get; set; }

    }
}
