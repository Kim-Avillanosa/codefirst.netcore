using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Controllers
{ 
    public class UserGroupController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetUserGroupCollectionQuery());

            if (response.Count() > 0)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetUserGroupByIdQuery(id));

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
