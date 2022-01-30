using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        public UserDBContext Context { get; }

        public DeleteUserHandler(UserDBContext context)
        {
            Context = context;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {

            var user = Context.Users.FirstOrDefault(item => item.Id == request.Id);

            Context.Users.Remove(user);

            Context.SaveChanges();

            return Unit.Value;
        }
    }
}
