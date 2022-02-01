using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class DeleteUserGroupHandler : IRequestHandler<DeleteUserGroupCommand>
    {
        private readonly IUserGroupRepository userGroupRepository;

        public DeleteUserGroupHandler(IUserGroupRepository userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }

        public async Task<Unit> Handle(DeleteUserGroupCommand request, CancellationToken cancellationToken)
        {
            await userGroupRepository.DeleteAsync(request.Id);

            return Unit.Value;
        }
    }
}
