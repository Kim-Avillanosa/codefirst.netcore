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

        /// <summary>
        /// Fetch list of user groups
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Fetch user group detail by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Add user group
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddUserGroupModel user)
        {
            var response = await Mediator.Send(new AddUserGroupCommand(user.Name));
            return NoContent();
        }


        /// <summary>
        /// Update user group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserGroupModel user)
        {
            var response = await Mediator.Send(new UpdateUserGroupCommand(id, user.Name));
            return NoContent();
        }


        /// <summary>
        /// Remove user group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteUserGroupCommand(id));
            return NoContent();
        }


    }
}
