using CodeFirst.NetCore.DbContexts;
using CodeFirst.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : Controller
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
    }
}
