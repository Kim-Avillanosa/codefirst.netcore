using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class GetUserGroupByIdQuery : IRequest<UserGroup>
    {
        public GetUserGroupByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
