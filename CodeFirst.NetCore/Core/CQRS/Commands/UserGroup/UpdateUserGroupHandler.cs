using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UpdateUserGroupHandler : IRequestHandler<UpdateUserGroupCommand>
    {
        private readonly IUserGroupRepository userGroupRepository;

        public UpdateUserGroupHandler(IUserGroupRepository userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }

        public async Task<Unit> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken)
        {
            var user = new UserGroup()
            {
                Name = request.Name,
            };

           await userGroupRepository.UpdateAsync(request.Id, user);

            return Unit.Value;
        }
    }
}
