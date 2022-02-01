using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class AddUserGroupCommandValidator : AbstractValidator<AddUserGroupCommand>
    {
        public AddUserGroupCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
