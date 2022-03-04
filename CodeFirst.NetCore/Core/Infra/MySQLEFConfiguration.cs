using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class MySQLEFConfiguration
    {
        public class UserConfiguration : BaseEntityTypeConfiguration<User>
        {
            public override void Configure(EntityTypeBuilder<User> builder)
            {

                //Define tables
                builder.ToTable("Users");

                //define uniqueness and index
                builder.HasIndex(u => u.FirstName)
                    .HasDatabaseName("Idx_FirstName");

                //define uniqueness and index
                builder.HasIndex(u => u.LastName)
                    .HasDatabaseName("Idx_LastName");


                //define columns

                builder.Property(u => u.FirstName)
                  .HasColumnName("FirstName")
                  .HasColumnType("nvarchar(100)")
                  .IsRequired();


                builder.Property(u => u.LastName)
                  .HasColumnName("LastName")
                  .HasColumnType("nvarchar(100)")
                  .IsRequired();


                //define relationship
                builder.HasOne<UserGroup>().WithMany().HasPrincipalKey(ug => ug.Id)
                  .HasForeignKey(u => u.UserGroupId)
                  .OnDelete(DeleteBehavior.NoAction)
                  .HasConstraintName("FK_Users_UserGroups");

                AddCreatedAndUpdatedAt(builder);

                //seed data
                builder.SeedUsers();


            }
        }



        public class UserGroupConfiguration : BaseEntityTypeConfiguration<UserGroup>
        {
            public override void Configure(EntityTypeBuilder<UserGroup> builder)
            {
                //Define tables
                builder.ToTable("UserGroups");

                //define uniqueness and index
                builder.HasIndex(p => p.Name)
                    .IsUnique()
                    .HasDatabaseName("Idx_Name");

                // define columns

                builder.Property(u => u.Name)
                  .HasColumnName("Name")
                  .HasColumnType("nvarchar(100)")
                  .IsRequired();

                AddCreatedAndUpdatedAt(builder);

                //Seed data

                builder.SeedUserGroups();
                 
            }
        }

        public class AddressConfiguration : BaseEntityTypeConfiguration<Address>
        {
            public override void Configure(EntityTypeBuilder<Address> builder)
            {

                //Define tables
                builder.ToTable("Address");

                //define uniqueness and index
                builder.HasIndex(u => u.ZipCode)
                    .HasDatabaseName("Idx_ZipCode");

                //define columns

                builder.Property(u => u.Street)
                  .HasColumnName("Street")
                  .HasColumnType("nvarchar(100)")
                  .IsRequired();

                builder.Property(u => u.Suite)
                   .HasColumnName("Suite")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

                builder.Property(u => u.ZipCode)
                   .HasColumnName("ZipCode")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

                builder.Property(u => u.City)
                   .HasColumnName("City")
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();


                builder.Property(x => x.Coordinates)
                    .HasColumnName("Coordinates")
                    .HasConversion(v => JsonConvert.SerializeObject(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<Coordinate>(v,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }))
                    .HasColumnType("json");


                builder.HasOne<User>().WithOne(x=>x.Address)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_Users_Address");

                AddCreatedAndUpdatedAt(builder);

                //seed data
                builder.SeedAddress();


            }
        }

    }
}
