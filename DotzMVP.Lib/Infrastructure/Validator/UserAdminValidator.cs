using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class UserAdminValidator : AbstractValidator<UserAdmin>
    {
        public UserAdminValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
