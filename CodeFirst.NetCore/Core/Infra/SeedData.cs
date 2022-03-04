using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
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
                 new User(1,1,"kmavillanosa@gmail.com","kmavillanosa", "Kim", "Avillanosa","09452873791","google.com"),
                 new User(2,2, "mperalta@gmail.com", "mperalta", "Mark", "Peralta", "09452873791", "google.com"),
                 new User(3,3, "erobles@gmail.com", "erobles",  "Elmer", "Robles", "09452873791", "google.com"));
        }

        public static void SeedAddress(this EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                 new Address(1,1,"Manalo Extension", "258-A", "PPC", "5300", new Coordinate { Longitude = "-7.77832031", Latitude = "53.2734" }));
        }
    }
}
