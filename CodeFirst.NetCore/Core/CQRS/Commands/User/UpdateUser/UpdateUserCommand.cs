using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserGroupId { get; set; }

        public UpdateUserCommand(int id,string firstName, string lastName, int userGroupId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserGroupId = userGroupId;
        }
    }
}
