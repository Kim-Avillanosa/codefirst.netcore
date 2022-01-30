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
        public UserDBContext Context { get; }

        public AddUserGroupHandler(UserDBContext context)
        {
            Context = context;
        }



        public async Task<Unit> Handle(AddUserGroupCommand request, CancellationToken cancellationToken)
        {
            var user = new UserGroup()
            {
                Name = request.Name,
            };

            Context.UserGroups.Add(user);

            await Context.SaveChangesAsync();


            return Unit.Value;
        }
    }
}
