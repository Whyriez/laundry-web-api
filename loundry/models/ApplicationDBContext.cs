using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace swagger_loundry.models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base(options)
        {

        }

        public virtual DbSet<Auth> Auth { get; set; }
        public virtual DbSet<Deposits> Deposits { get; set; }
        public virtual DbSet<Me> Me { get; set; }
      
        public virtual DbSet<Packages> Packages { get; set; }
        public virtual DbSet<PackageTransactions> PackageTransactions { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Users> Users { get; set; }

    }
}
