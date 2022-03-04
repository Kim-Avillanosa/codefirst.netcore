using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UpdateUserGroupCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UpdateUserGroupCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
