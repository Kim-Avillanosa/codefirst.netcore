using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {

        public UserDBContext Context { get; }

        public UpdateUserHandler(UserDBContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = Context.Users.FirstOrDefault(item => item.Id == request.Id);

            user.FirstName = request.FirstName;

            user.LastName = request.LastName;

            user.UserGroupId = request.UserGroupId;

            Context.Users.Update(user);

            await Context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
