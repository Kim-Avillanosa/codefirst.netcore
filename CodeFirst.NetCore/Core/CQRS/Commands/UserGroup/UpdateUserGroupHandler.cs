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
        public UserDBContext Context { get; }

        public UpdateUserGroupHandler(UserDBContext context)
        {
            Context = context;
        }



        public async Task<Unit> Handle(UpdateUserGroupCommand request, CancellationToken cancellationToken)
        {

            var user = Context.UserGroups.FirstOrDefault(item => item.Id == request.Id);

            user.Name = request.Name;

            Context.UserGroups.Update(user);

            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
