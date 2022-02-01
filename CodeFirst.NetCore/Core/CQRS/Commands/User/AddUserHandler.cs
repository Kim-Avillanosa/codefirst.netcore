using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserRepository repository;

        public AddUserHandler(IUserRepository repository)
        {
            this.repository = repository;
        }


        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserGroupId = request.UserGroupId
            };

            await repository.AddAsync(currentUser);

            return Unit.Value;
        }
    }
}
