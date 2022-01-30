using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore.Core.CQRS.Commands
{
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {

        public UserDBContext Context { get; }

        public AddUserHandler(UserDBContext context)
        {
            Context = context;
        }


        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserGroupId = request.UserGroupId
            };

            Context.Users.Add(user);

             await  Context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
