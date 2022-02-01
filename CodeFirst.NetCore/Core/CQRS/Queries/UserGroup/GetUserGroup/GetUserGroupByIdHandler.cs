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
        private readonly IUserGroupRepository userGroupRepository;

        public GetUserGroupByIdHandler(IUserGroupRepository userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }


        public async Task<UserGroup> Handle(GetUserGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await userGroupRepository.GetAsync(request.Id);

            return response;
        }
    }
}
