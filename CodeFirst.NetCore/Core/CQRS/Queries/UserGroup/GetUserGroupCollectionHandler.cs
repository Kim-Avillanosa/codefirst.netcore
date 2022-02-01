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
        private readonly IUserGroupRepository userGroupRepository;

        public GetUserGroupCollectionHandler(IUserGroupRepository userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }

        public async Task<IEnumerable<UserGroup>> Handle(GetUserGroupCollectionQuery request, CancellationToken cancellationToken)
        {
            var response = await userGroupRepository.GetListAsync();

            return response;
        }
    }
}
