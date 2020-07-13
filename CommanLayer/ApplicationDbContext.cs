using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace CommanLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Quantity> Quantities { get; set; }

    }
}
