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
        public UserDBContext Context { get; }

        public DeleteUserGroupHandler(UserDBContext context)
        {
            Context = context;
        }


        public async Task<Unit> Handle(DeleteUserGroupCommand request, CancellationToken cancellationToken)
        {
            var usergroup = Context.UserGroups.FirstOrDefault(item => item.Id == request.Id);

            Context.UserGroups.Remove(usergroup);

            Context.SaveChanges();

            return Unit.Value;
        }
    }
}
