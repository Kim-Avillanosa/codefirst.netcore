using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace CodeFirst.NetCore.Test
{
    public static class DbContextFactory
    {
        public static UserDBContext Create()
        {
            //Initialize ef dbconfig instance
            var options = new DbContextOptionsBuilder<UserDBContext>()
              .UseInMemoryDatabase(Guid.NewGuid().ToString())
              .EnableSensitiveDataLogging()
              .Options;

            ///create dbContext instance
            var context = new UserDBContext(options);

            /////Seed user
            //context.AddUser();

            ////Seed user group
            //context.AddUserGroup();

            ////Seed address
            //context.AddAddress();

            //Ensures that the database is created
            context.Database.EnsureCreated();

            //commit changes
            context.SaveChanges();

            //return instance
            return context;
        }
    }

}
