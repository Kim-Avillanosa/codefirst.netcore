using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UserDBContext : DbContext
    {

        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }


        public UserDBContext(DbContextOptions<UserDBContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("utf8_general_ci");

            // apply configurations
            modelBuilder.ApplyConfiguration(new MySQLEFConfiguration.UserConfiguration());
            modelBuilder.ApplyConfiguration(new MySQLEFConfiguration.UserGroupConfiguration());
            modelBuilder.ApplyConfiguration(new MySQLEFConfiguration.AddressConfiguration());

        }

    }
}
