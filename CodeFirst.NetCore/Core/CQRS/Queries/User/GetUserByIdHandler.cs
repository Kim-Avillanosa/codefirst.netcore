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
        public UserDBContext Context { get; }

        public GetUserByIdHandler(UserDBContext context)
        {
            Context = context;
        }


        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var response =  Context.Users.FirstOrDefault(item => item.Id == request.Id);

            return await Task.FromResult(response);
        }
    }
}
