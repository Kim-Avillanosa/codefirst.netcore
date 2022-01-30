using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class AddUserCommand : IRequest
    {
  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserGroupId { get; set; }

        public AddUserCommand(string firstName, string lastName, int userGroupId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserGroupId = userGroupId;
        }
    }
}
