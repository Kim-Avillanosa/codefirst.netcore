using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UpdateUserCommandValidator :  AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();

            RuleFor(x => x.UserGroupId).NotEmpty().NotNull();

            RuleFor(x => x.FirstName).MaximumLength(10).NotEmpty().NotNull();

            RuleFor(x => x.LastName).MaximumLength(10).NotEmpty().NotNull();

        }
    }
}
