using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

    }
}
