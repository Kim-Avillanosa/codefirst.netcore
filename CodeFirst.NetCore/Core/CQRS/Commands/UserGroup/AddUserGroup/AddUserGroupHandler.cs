using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class AddUserGroupHandler : IRequestHandler<AddUserGroupCommand>
    {
        private readonly IUserGroupRepository userGroupRepository;

        public AddUserGroupHandler(IUserGroupRepository userGroupRepository)
        {
            this.userGroupRepository = userGroupRepository;
        }



        public async Task<Unit> Handle(AddUserGroupCommand request, CancellationToken cancellationToken)
        {
            var user = new UserGroup()
            {
                Name = request.Name,
            };
            
            await userGroupRepository.AddAsync(user);

            return Unit.Value;
        }
    }
}
