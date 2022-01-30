using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class GetUserGroupCollectionHandler : IRequestHandler<GetUserGroupCollectionQuery, IEnumerable<UserGroup>>
    {

        public UserDBContext Context { get; }

        public GetUserGroupCollectionHandler(UserDBContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<UserGroup>> Handle(GetUserGroupCollectionQuery request, CancellationToken cancellationToken)
        {
            var response = Context.UserGroups.ToList();

            return await Task.FromResult(response);
        }
    }
}
