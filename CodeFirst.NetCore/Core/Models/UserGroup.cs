using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UserGroup : Entity
    {

        public UserGroup()
        {

        }
        public UserGroup(int id, string name)
        {
            Id = id;
            Name = name;

        }

        public string Name { get; set; }

    }
}
