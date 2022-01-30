using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Core
{
    public static class SeedData
    {
        public static void SeedUserGroups(this EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasData(
                 new UserGroup(1, "Administrator"),
                 new UserGroup(2, "Standard"),
                 new UserGroup(3, "Guest"));
        }



        public static void SeedUsers(this EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                 new User(1, "Kim", "Avillanosa", 1),
                 new User(2, "Mark", "Peralta", 2),
                 new User(3, "Elmer", "Robles", 3));
        }
    }
}
