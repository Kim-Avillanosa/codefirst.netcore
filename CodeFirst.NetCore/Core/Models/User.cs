using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class User  : Entity
    {

        public int UserGroupId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        internal Address Address { get; set; }

        public User()
        {

        }

        public User(int id,int userGroupId, string email, string userName, string firstName, string lastName, string phone, string website)
        {
            Id = id;
            UserGroupId = userGroupId;
            Email = email;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Website = website;
        }
    }
}
