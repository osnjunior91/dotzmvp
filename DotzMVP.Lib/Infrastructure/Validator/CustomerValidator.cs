using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.RegistrationNumber).NotNull().NotEmpty().MinimumLength(11).MaximumLength(14);
            RuleFor(x => x.FantasyName).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(14);
        }
    }
}
