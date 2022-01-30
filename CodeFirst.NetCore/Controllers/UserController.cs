using CodeFirst.NetCore.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new GetUserCollectionQuery());

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
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));

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
        public async Task<IActionResult> Add([FromBody]AddUserModel user)
        {
            var response = await Mediator.Send(new AddUserCommand(user.FirstName, user.LastName, user.UserGroupId));
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserModel user)
        {
            var response = await Mediator.Send(new UpdateUserCommand(id, user.FirstName, user.LastName, user.UserGroupId));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(id));
            return NoContent();
        }


    }
}
