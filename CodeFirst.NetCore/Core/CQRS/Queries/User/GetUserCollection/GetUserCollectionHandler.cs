using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class GetUserCollectionHandler : IRequestHandler<GetUserCollectionQuery, IEnumerable<User>>
    {
        private readonly IUserRepository userRepository;

        public GetUserCollectionHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> Handle(GetUserCollectionQuery request, CancellationToken cancellationToken)
        {
            var response = await userRepository.GetListAsync();

            return await Task.FromResult(response);
        }
    }
}
