using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class GetUserGroupByIdHandler : IRequestHandler<GetUserGroupByIdQuery, UserGroup>
    {
        public UserDBContext Context { get; }

        public GetUserGroupByIdHandler(UserDBContext context)
        {
            Context = context;
        }


        public async Task<UserGroup> Handle(GetUserGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var response = Context.UserGroups.FirstOrDefault(item => item.Id == request.Id);

            return await Task.FromResult(response);
        }
    }
}
