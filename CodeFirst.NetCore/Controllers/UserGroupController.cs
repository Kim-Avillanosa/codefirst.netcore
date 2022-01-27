using CodeFirst.NetCore.DbContexts;
using CodeFirst.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Controllers
{ 
    public class UserGroupController : BaseController
    {

        private UserDBContext myDbContext;
        public UserGroupController(UserDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<UserGroup> Get()
        {
            return (this.myDbContext.UserGroups.ToList());
        }
        [HttpPost]
        public ActionResult<IList<UserGroup>> Add()
        {
            myDbContext.UserGroups.Add(new UserGroup() 
            {
                 CreationDateTime = DateTime.Now,
                 Id= 1,
                 Name = "Kim Avillanosa",
            });
            myDbContext.SaveChanges();

            return Created("google.com", 1);
        }
    }
}
