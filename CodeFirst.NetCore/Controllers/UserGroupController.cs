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



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserGroupModel user)
        {
            var response = await Mediator.Send(new AddUserGroupCommand(user.Name));
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserGroupModel user)
        {
            var response = await Mediator.Send(new UpdateUserGroupCommand(id, user.Name));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteUserGroupCommand(id));
            return NoContent();
        }


    }
}
