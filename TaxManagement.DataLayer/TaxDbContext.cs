using TaxManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxManagement.DataLayer
{
    public class TaxDbContext : DbContext
    {
        public TaxDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tax> Taxes { get; set; }
    }

}