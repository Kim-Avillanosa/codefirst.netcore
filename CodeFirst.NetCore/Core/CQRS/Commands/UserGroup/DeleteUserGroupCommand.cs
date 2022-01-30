using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class DeleteUserGroupCommand : IRequest
    {
        public DeleteUserGroupCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
