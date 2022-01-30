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
        public UserDBContext Context { get; }

        public GetUserCollectionHandler(UserDBContext context)
        {
            Context = context;
        }


        public async Task<IEnumerable<User>> Handle(GetUserCollectionQuery request, CancellationToken cancellationToken)
        {
            var response = Context.Users.ToList();

            return await Task.FromResult(response);
        }
    }
}
