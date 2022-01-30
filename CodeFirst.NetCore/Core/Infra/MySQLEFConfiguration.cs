using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Core
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
    }
}
