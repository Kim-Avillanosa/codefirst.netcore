using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UpdateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserGroupId { get; set; }
        public UpdateUserModel(string firstName, string lastName, int userGroupId)
        {
            FirstName = firstName;
            LastName = lastName;
            UserGroupId = userGroupId;
        }

    }
}
