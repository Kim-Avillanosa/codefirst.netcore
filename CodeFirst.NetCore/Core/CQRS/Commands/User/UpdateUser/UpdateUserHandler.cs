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
        private readonly IUserRepository userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
    
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserGroupId = request.UserGroupId
            };

           await userRepository.UpdateAsync(request.Id, currentUser);
            
            return Unit.Value;
        }
    }
}
