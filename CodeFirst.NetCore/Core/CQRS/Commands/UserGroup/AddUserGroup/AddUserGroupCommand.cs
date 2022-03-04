using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class AddUserGroupCommand : IRequest
    {
        public string Name { get; set; }

        public AddUserGroupCommand(string name)
        {
            Name = name;
        }

    }
}
