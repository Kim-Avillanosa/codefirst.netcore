using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class DeleteUserGroupCommandValidator : AbstractValidator<DeleteUserGroupCommand>
    {
        public DeleteUserGroupCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}
