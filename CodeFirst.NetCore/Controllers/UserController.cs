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
    public class UserController : ControllerBase
    {
        private UserDBContext myDbContext;

        public UserController(UserDBContext context)
        {
            myDbContext = context;
        }

        [HttpGet]
        public IList<User> Get()
        {
            return (this.myDbContext.Users.ToList());
        }
    }
}
