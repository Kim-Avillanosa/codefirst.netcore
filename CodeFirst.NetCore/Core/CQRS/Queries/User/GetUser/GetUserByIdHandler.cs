using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User> 
    {
        private readonly IUserRepository userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await userRepository.GetAsync(request.Id);

            return await Task.FromResult(response);
        }
    }
}
