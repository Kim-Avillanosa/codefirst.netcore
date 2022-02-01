using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class GetUserGroupByIdValidator : AbstractValidator<GetUserGroupByIdQuery>
    {
        public GetUserGroupByIdValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
