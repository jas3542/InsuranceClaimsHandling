using InsuranceClaimsHandling.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsHandling
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LossType> LossTypes { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}
